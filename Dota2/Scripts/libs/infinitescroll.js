(function (factory) {
	// Module systems magic dance.

    /* istanbul ignore next - (code coverage ignore) */
	if (typeof require === "function" && typeof exports === "object" && typeof module === "object") {
		// CommonJS or Node: hard-coded dependency on "knockout"
		factory(require("knockout"), exports);
	} else if (typeof define === "function" && define["amd"]) {
		// AMD anonymous module with hard-coded dependency on "knockout"
		define(["knockout", "exports"], factory);
	} else {
		// <script> tag: use the global `ko` object
		factory(ko, {});
	}
}(function (ko, exports) {
	ko.extenders.infinitescroll = function(target, args) {
		var props = {};

		target.infinitescroll = props;

		/*
		 * PROVIDED PROPERTIES
		 */

		// App to calculate and provide viewport dimensions, usually from a resize listener like $('#scrollingDiv').resize(...).
		// The viewport is the div/element that holds items and will be scrolled.
		props.viewportWidth = ko.observable(-1);
		props.viewportHeight = ko.observable(-1);

		// App to calculate and provide dimensions of individual items.
		// These are the items that will be scrolled in the viewport.
		props.itemWidth = ko.observable(-1);
		props.itemHeight = ko.observable(-1);

		// App to detect and provide current scroll position, for example using jquery: $(document).scroll(function() { self.filteredItems.infinitescroll.scrollY(windowRef.scrollTop()); });
		props.scrollY = ko.observable(0);

		// If using a scrollbar of container that is not the scrolling element, the gap between the scroller height and scrollee height is the scrollYOffset (in px).
		// The most common use of this is to use the native browser scroller to scroll a specific div within the site.
		// For example if we are using an 800px tall native browser scroller to scroll an inner div that's 700px tall, the scrollYOffset is 100.
		props.scrollYOffset = ko.observable(0);

		// The number of "pages" (page = numCols * numRows) pre-loaded before and after the current scrolled page.
		// Minimum 1, because 0 padding would disable scrolling.
		// For example, if your page fits 10 items, and numPagesPadding is 3, then 30 items will be pre-loaded before and after the current scroll position, for a maximum of 70 items loaded at any given time.
		props.numPagesPadding = ko.observable(parseFloat(args.numPagesPadding) || 1);

		/*
		 * CALCULATED PROPERTIES (bindable and available to your app)
		 */

		// Number of columns that can fit on a single page given the item dimensions and viewport dimensions
		props.numColsPerPage = ko.computed(function() {
			var viewportWidth = parseInt(props.viewportWidth()),
				itemWidth = parseInt(props.itemWidth()) || -1;
			return Math.max(Math.floor(viewportWidth / itemWidth), 0);
		});

		// Number of rows that can fit on a single page given the item dimensions and viewport dimensions
		props.numRowsPerPage = ko.computed(function() {
			var viewportHeight = parseInt(props.viewportHeight()),
				itemHeight = parseInt(props.itemHeight()) || -1;
			return Math.max(Math.ceil(viewportHeight / itemHeight), 0);
		});

		// Total number of items that can fit on a single page (cols * rows) given the item dimensions and viewport dimensions
		props.numItemsPerPage = ko.computed(function() {
			var numColsPerPage = parseInt(props.numColsPerPage()),
				numRowsPerPage = parseInt(props.numRowsPerPage());
			return numColsPerPage * numRowsPerPage;
		});

		// Total number of items padded (pre-loaded) after visible page. For example, if 10 items fit per page, and numPagesPadding is 3, there would be 40 total items loaded, and numItemsPadding would be 30.
		props.numItemsPadding = ko.computed(function() {
			var numItemsPerPage = props.numItemsPerPage(),
				numPagesPadding = props.numPagesPadding(),
				numColsPerPage = props.numColsPerPage();
			return Math.max(Math.floor(numItemsPerPage * numPagesPadding / numColsPerPage) * numColsPerPage, numColsPerPage);
		});

		// The 0-based index of the first item visible at the current scroll position. For example, if 10 items fit per page, and user scrolled to second page, the firstVisibleIndex would be 10 (the first page would have items 0-9, so the first index on the second page would be 10)
		props.firstVisibleIndex = ko.computed(function() {
			var scrollY = parseInt(props.scrollY()),
				scrollYOffset = parseInt(props.scrollYOffset()),
				itemHeight = parseInt(props.itemHeight()) || -1,
				numColsPerPage = props.numColsPerPage();
			return Math.max(Math.floor((scrollY - scrollYOffset) / itemHeight) * numColsPerPage, 0);
		});

		// The 0-based index of the last item visible at the current scroll position. For example, if 10 items fit per page, and user scrolled to second page, the lastVisibleIndex would be 19 (the first page would have items 0-9, the second page would have 10-19, so the last index would be 19)
		props.lastVisibleIndex = ko.computed(function() {
			return props.firstVisibleIndex() + props.numItemsPerPage();
		});

		// The 0-based index of the first item that is NOT rendered. For example, if 10 items fit per page, and numPagesPadding is 1, and user scrolled to page 3, then items 0-9 would be not rendered, and the firstHiddenIndex would be 9 (not 0).
		props.firstHiddenIndex = ko.computed(function() {
			return Math.max(props.firstVisibleIndex() - props.numItemsPadding(), 0);
		});

		// The 0-based index of the last item that is NOT rendered. For example, if 10 items fit per page, and numPagesPadding is 1, and user scrolled to page 3, then items 21-30 would be showing, items 31-40 would be rendered but out of view, and the 41st item (index 40) would be the lastHiddenIndex.
		props.lastHiddenIndex = ko.computed(function() {
			return Math.min(props.lastVisibleIndex() + props.numItemsPadding(), target().length);
		});

		// The combined height (in px) of all unrendered items before viewport, (had they been rendered). For example, if 10 items fit per page, each item is 10px tall, numPagesPadding is 1, and user scrolled to page 3, then items 1-10 would not be rendered, and the heightBefore would be 100 (10 unrendered items * 10px each).
		props.heightBefore = ko.computed(function() {
			return Math.max(props.firstHiddenIndex() / props.numColsPerPage() * props.itemHeight(), 0);
		});

		// The combined height (in px) of all unrendered items after viewport (had they been rendered). For example, if 10 items fit per page, each item is 10px tall, numPagesPadding is 1, collection has 100 total items, and user scrolled to page 3, then items 41-100 would not be rendered, and the heightAfter would be 600 (70 unrendered items * 10px each).
		props.heightAfter = ko.computed(function() {
			return Math.max(((target().length - 1 - props.lastHiddenIndex()) / props.numColsPerPage()) * props.itemHeight(), 0);
		});

		// display items
		props.displayItems = ko.observableArray([]);
		ko.computed(function() {
			var oldDisplayItems = props.displayItems.peek(),
				newDisplayItems = target.slice(0, props.lastHiddenIndex());

			if (oldDisplayItems.length !== newDisplayItems.length) {
				props.displayItems(newDisplayItems);
				return;
			}

			// if collections are not identical, skip, replace with new items
			for (var i = newDisplayItems.length - 1; i >= 0; i--) {
				if (newDisplayItems[i] !== oldDisplayItems[i]) {
					props.displayItems(newDisplayItems);
					return;
				}
			}
		});
	};
}));