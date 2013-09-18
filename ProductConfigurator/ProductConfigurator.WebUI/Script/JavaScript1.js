/// <reference path="jquery-1.9.1.min.js" />


$(function () {

	ajax("#Product", "Admin/ProductPartial");

	$('#ProductList').change(function () {


		var myselect = document.getElementById("ProductList");
		var productId = myselect.options[myselect.selectedIndex].value;
		ajax("#Category", "Admin/CategoryPartial", productId);
	});

});

function SaveObj(name, path) {
	var baseUrl = "http://" + location.host + "/" + path + "/" + id;

	$.ajax({
		type: "GET",
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

function ajax(pos, path, id) {
	var baseUrl = "http://" + location.host + "/" + path + "/" + id;
	
	if (id == null) {
		$.ajax({
			type: "GET",
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
			async: false,
			success: function (result) {
				$(pos).html(result);
			},
			error: function (xhr, status) {
				alert(status);
			}
		});
	}
}