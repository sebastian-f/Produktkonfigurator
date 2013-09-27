$(document).ready(function () {

    $('select').change(selectChange);

});

function Submit() {
    $("form").submit();
}

function selectChange() {
    var select = $(this).attr("name")
    var id = $(this).val();
    if (select == "Product" && id != "") {
        $.ajax({
            url: CategoryPartialUrl,
            data: { 'productId': id },
            type: "post",
            success: function (data) {
                $("#categoryPartial").html(data);
                $('#btnSubmit').click(Submit);
                $('select').change(selectChange);
            },
            error: function () {
                alert("error");
            }
        });
    }

    else if (select == "Product" && id == "")
        $("#categoryPartial").html("");

    else if (select != "Product" && id != "") {
        var partId = $(this).val();
        var klickad = $(this).attr('name');

        var selectList = new Array();
        var partIdsToCompare = "";
        $('.partSelect').each(function () {
            if ($(this).val() != "") {
                selectList.push({ selectName: $(this).attr('name'), selectedOption: $(this).val() });
                partIdsToCompare += $(this).val() + ",";
                //if(klickad != 
            }
        });
        debugger;
        if (partIdsToCompare != "") {
            $('.partSelect').each(function () {
                var $this = $(this);
                if ($(this).val() != partId) {
                    $.ajax({
                        url: RelationPartialsPartUrl,
                        data: { 'partIdsString': partIdsToCompare, 'categoryId': $(this).attr('name') },
                        type: "post",
                        async: true,
                        success: function (data) {
                            $this.html(data);
                            debugger;
                            for (var i = 0; i < selectList.length; i++) {
                                $('.partSelect').each(function () {
                                    if ($(this).attr('name') == selectList[i].selectName) {
                                        $(this).val(selectList[i].selectedOption);
                                    }
                                });
                            }
                        },
                        error: function () {
                            alert("error");
                        }
                    });
                }
            });
        }
    }


}