/// <reference path="jquery-1.9.1.min.js" />


$(function () {

	ajax("#Product", "http://localhost:10764/Admin/ProductPartial");
	


	//alert($('#ProductList :selected').val());


	$('#ProductList').change(function () {


		var myselect = document.getElementById("ProductList");
		var productId = myselect.options[myselect.selectedIndex].value;
		ajax("#Category", "Admin/CategoryPartial", productId);
	});

});


function ajax(pos, url, id) {
	var baseUrl = "http://localhost:10764/" + url + "/" + id;

	if (id == null) {
		$.ajax({
			type: "POST",
			url: baseUrl,
			async: false,
			success: function (result) {
				$(pos).html(result);
			},
			error: function (xhr, status) {
				alert(status);
			}
		});
	}
	else {
		$.ajax({
			type: "GET",
			url: baseUrl,
			success: function (result) {
				$(pos).html(result);
			},
			error: function (xhr, status) {
				alert(baseUrl);
				alert(status);
			}
		});
	}
}