$(".details").click(function () {
    debugger;
    var idCliente = $(this).attr("data-idCliente");
    var idFornecedor = $(this).attr("data-idFornecedor");
    $("#modal").load("Tarefas/RealizarTarefas?idCliente=" + idCliente + "&idFornecedor=" + idFornecedor, function () {
        $("#modal").modal();
    })
});