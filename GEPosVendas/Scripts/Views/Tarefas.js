var Tarefas = function () {

    this.DetalharCliente = function (obj) {
        var urlDetalhe = $(obj).attr("data-url");
        var idDetalheHtml = $(obj).attr("data-target");
        var panelBody = $(idDetalheHtml);

        $.ajax({
            type: 'GET',
            url: urlDetalhe + "",
            success: function (partialHtml) {
                panelBody.html(partialHtml);
            },
            error: function (error) {
                alert('error; ' + eval(error));
            }
        });
    }

    this.RealizarTarefas = function (obj) {
        var idCliente = $(obj).attr("data-idCliente");
        var idFornecedor = $(obj).attr("data-idFornecedor");
        $("#modal").load("Tarefas/RealizarTarefas?idCliente=" + idCliente + "&idFornecedor=" + idFornecedor, function () {
            $("#modal").modal();
        })
    }
}

$(document).ready(function () {
    tarefas = new Tarefas();
});