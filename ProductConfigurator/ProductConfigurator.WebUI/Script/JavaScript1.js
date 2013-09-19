/// <reference path="jquery-1.9.1.min.js" />


$(function () {

	ajax("#Product", "Admin/ProductPartial");


	$('#ProductList').change(function () {


		var productId = $('#ProductList :selected').val();

		ajax("#Category", "Admin/CategoryPartial", productId);

		$('#productId').val($('#ProductList :selected').val());

		$('#Part').html('');


		$('#CategoryList').change(function () {
			var categoryId = $('#CategoryList :selected').val();
	
			ajax("#Part", "Admin/PartPartial", categoryId);
	
			$('#categoryId').val($('#CategoryList :selected').val());


			$('#PartList').change(function () {
				var partId = $('#PartList :selected').val();

				ajax("#PartDetails", "Admin/PartDetailsPartial", productId);

				$('#partId').val($('#PartList :selected').val());




			});
		});
	});
});


/*
function SaveObj(name, path) {
	var baseUrl = "http://" + location.host + "/" + path

	var productId = $('#ProductList :selected').val()

	$.ajax({
		type: "POST",
		url: baseUrl,
		async: false,
		data: { name: name, productId: productId },
		success: function (result) {
			$(pos).html(result);
		},
		error: function (xhr, status) {
			alert(status);
		}
	});
	
}
*/
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