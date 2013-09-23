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

				ajaxPartDetailsPartial("#PartDetails", productId, partId);

				$('#partId').val($('#PartList :selected').val());
				
				$(".box").click(function () {
					var list = new Array();
					list[0] = $(this).attr('value');
					SaveRels(list);
				});
				

				/*
				$('#relation').click(function () {
					var list = new Array();
					var i = 0;
					$(".box").each(function () {
						if ($(this).prop('checked')) {
							list[i] = $(this).attr('value');
							i++;
						}
					});
					SaveRels(list);


				});*/
			});
		});
	});
});


function SaveRels(idList) {
	var productId = $('#PartList :selected').val();

	for (var i = 0; i < idList.length; i++) {


		var baseUrl = "http://localhost:10764" + "/Admin/AddRelation?oneId=" + productId + "&twoId=" + idList[i];

		$.ajax({
			type: "POST",
			url: baseUrl,
			async: true,
			//data: { oneId: productId, twoId: idList },
			success: function (result) {
				alert("success");
			},
			error: function (xhr, status) {
				alert(status);
			}
		});
	}
}

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



function ajaxPartDetailsPartial(pos, id, partId) {
	var baseUrl = "http://" + location.host + "/Admin/PartDetailsPartial?productId=" + id + "&partId=" + partId;

	$.ajax({
		type: "GET",
		url: baseUrl,
		async: false,
		success: function (result) {
			$(pos).html(result);
		},
		error: function (xhr, status) {
			//alert(status);
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
				//alert(status);
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
				//alert(status);
			}
		});
	}
}