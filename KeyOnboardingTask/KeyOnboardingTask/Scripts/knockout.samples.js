viewModel = function () {
    var self = this
    self.ProductSoldCollection = ko.observableArray();
    ////.done(function (data) {
    //$(data).each(function (index, element) {
    //    var mappedItem = 
    //    {
    //        Id: ko.observable(element.Id),
    //        Customer: ko.observable(element.Customer),
    //        Product: ko.observable(element.Product),
    //        Store: ko.observable(element.Store),
    //        DateSold: ko.observable(element.DateSold),
    //        Mode: ko.observable("display")
    //    }
    //    viewModel.ProductSoldCollection.push(mappedItem);
    //});
    //ko.applyBindings(viewModel);
};


$(document).ready(function () {
	$.ajax({
		type: "GET",
		url: "/ProductSolds/GetIndex",
	}).done(function (data) {
	    $(data).each(function (index, element) {
	        var mappedItem =
       {
           Id: ko.observable(element.Id),
           Customer: ko.observable(element.Customer),
           Product: ko.observable(element.Product),
           Store: ko.observable(element.Store),
           DateSold: ko.observable(element.DateSold),
           Mode: ko.observable("display")
       }
			viewModel.ProductSoldCollection.push(element);
		});
		ko.applyBindings(viewModel);
	})
        .error(function (ex) {
		alert("Error");
	});
});

$(document).on("click", "#create", null, function (ev) {
    var current = {
        Id: ko.observable(0),
        Customer: ko.observable(),
        Product: ko.observable(),
        Store: ko.observable(),
        DateSold: ko.observable(),

        Mode: ko.observable("edit")
    }
    viewModel.ProductSoldCollection.push(current);
});
