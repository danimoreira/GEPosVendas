this.idClientSelected = 0;

var Tarefas = function () {

    this.DeleteClassActiveShowOthers = function (obj) {
        $(".active").filter(".show").each(function () {
            if ($(this) != $(obj)) {
                $(this).removeClass("active");
                $(this).removeClass("show");
            }
        })
    }

    this.SelecionarVendedor = function (idVendedor) {
        if ($('#idVendedorSelecionado').val() != idVendedor)
            $('#idVendedorSelecionado').val(idVendedor);
    }

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
        var urlRealizarTarefas = $(obj).attr("data-urlRealizarTarefas");
        $("#modal").load(urlRealizarTarefas, function () {
            $("#modal").modal({ backdrop: 'static', keyboard: false });
            tarefas.inicializaDatePicker();
        })
    }

    this.SelecionarCliente = function (idCliente) {
        $('#idClienteSelecionado').val(idCliente);
    }

    this.inicializaDatePicker = function () {
        $(".datepicker").datepicker({
            format: 'dd/mm/yyyy', orientation: "auto", autoclose: true, todayBtn: "linked", language: "pt-BR"
        });
    }

    this.ExcluirHistórico = function (obj, idHistorico, idCliente, idFornecedor) {
        alertify.confirm("Deseja excluir este agendamento?", function (e) {
            if (e) {
                var urlDetalhe = $(obj).attr("data-url");
                var panelBody = $("#modal");

                var idClienteSelecionado = $("[name=idClienteSelecionado]").val();
                idClienteSelecionado = idClienteSelecionado == "" ? 0 : idClienteSelecionado;
                var idVendedorSelecionado = $('#idVendedorSelecionado').val();
                idVendedorSelecionado = idVendedorSelecionado == "" ? 0 : idVendedorSelecionado;

                $.ajax({
                    type: 'POST',
                    url: urlDetalhe + "",
                    data: { "idHistorico": idHistorico, "idCliente": idCliente, "idFornecedor": idFornecedor, "idClienteSelecionado": idClienteSelecionado, "idVendedorSelecionado": idVendedorSelecionado },
                    success: function (partialHtml) {
                        toastr.success("Agendamento excluído com sucesso");
                        panelBody.html(partialHtml);
                        tarefas.inicializaDatePicker();
                    },
                    error: function (error) {
                        alert('error; ' + eval(error));
                    }
                });
            }
        });
    }

    this.EditarHistorico = function (obj) {

        $(obj).addClass("disabled");

        var urlDetalhe = $(obj).attr("data-url");
        var panelBody = $("#modal");

        $.ajax({
            type: 'POST',
            url: urlDetalhe + "",
            success: function (partialHtml) {
                panelBody.html(partialHtml);
                tarefas.inicializaDatePicker();
            },
            error: function (error) {
                alert('error; ' + eval(error));
            }
        });

    }

    this.SalvarHistorico = function (obj) {
        var isValid = true;

        if ($("[name=DataContato]").val() == "") {
            $("[name=DataContato]").addClass("has-error");
            isValid = false;
        }

        if ($("[name=Descricao]").val() == "") {
            $("[name=Descricao]").addClass("has-error");
            isValid = false;
        }

        if ($("[name=DataAgenda]").val() == "") {
            $("[name=DataAgenda]").addClass("has-error");
            isValid = false;
        }

        if (!isValid) {
            toastr.warning("Favor preencher os campos obrigatórios.");
            return false;
        }

        var urlDetalhe = $(obj).attr("data-url");
        var panelBody = $("#modal");

        var contato =
            {
                Id: $("[name=Id]").val(),
                IdVendedor: $("[name=IdVendedor]").val(),
                IdCliente: $("[name=IdCliente]").val(),
                IdFornecedor: $("[name=IdFornecedor]").val(),
                Descricao: $("[name=Descricao]").val(),
                DataContato: $("[name=DataContato]").val(),
                DataCompra: $("[name=DataCompra]").val(),
                DataAgenda: $("[name=DataAgenda]").val(),
                DataReagenda: null,
                Situacao: 0
            }

        var idClienteSelecionado = $("[name=idClienteSelecionado]").val();
        idClienteSelecionado = idClienteSelecionado ? idClienteSelecionado : 0;
        var idVendedorSelecionado = $('#idVendedorSelecionado').val();
        idVendedorSelecionado = idVendedorSelecionado ? idVendedorSelecionado : 0;


        $.ajax({
            type: 'POST',
            url: urlDetalhe + "",
            data: {
                contato: contato, idClienteSelecionado: idClienteSelecionado, idVendedorSelecionado: idVendedorSelecionado
            },
            success: function (partialHtml) {
                toastr.success("Agendamento salvo com sucesso");
                $(obj).removeClass("disabled");
                alertify.confirm("Deseja realizar outro agendamento para este mesmo cliente?", function (e) {
                    if (e) {
                        panelBody.html(partialHtml);
                    } else {
                        tarefas.ReloadTarefas();
                    }
                });
                tarefas.inicializaDatePicker();
            },
            error: function (error) {
                toastr.error('error; ' + eval(error));
            }
        });
    }

    this.AlterarFornecedor = function (obj) {
        var urlDetalhe = $(obj).attr("data-url");
        var panelBody = $("#modal");
        
        var urlAction = $("#urlRecuperarDetalhes").val();

        $.ajax({
            type: 'GET',
            url: urlAction,
            data: { "idCliente": $("[name = IdCliente]").val(), "idFornecedor": $("[name = IdFornecedor]").val() },
            success: function (partialHtml) {
                panelBody.html(partialHtml);
                tarefas.inicializaDatePicker();
            },
            error: function (error) {
                alert('error; ' + eval(error));
            }
        });
    }

    this.ReloadTarefas = function () {
        $("#modal").modal('hide');

        var idClienteSelecionado = $("[name=idClienteSelecionado]").val();
        idClienteSelecionado = idClienteSelecionado == "" ? 0 : idClienteSelecionado;
        var idVendedorSelecionado = $('#idVendedorSelecionado').val();
        idVendedorSelecionado = idVendedorSelecionado ? idVendedorSelecionado : 0;
        
        var urlAction = $("#urlReloadTarefas").val();

        $.ajax({
            type: 'GET',
            url: urlAction,
            data: {
                "idClienteSelecionado": idClienteSelecionado, "idVendedorSelecionado": idVendedorSelecionado
            },
            dataType: 'html',
            cache: false,
            async: true,
            success: function (resultView) {

                $("#modal").modal('hide');
                $("main").html(resultView);

                

                if (idVendedorSelecionado != 0)
                    $("#groupVendedor" + idVendedorSelecionado).trigger("click");

                if (idClienteSelecionado != 0) {

                    $('#loadingDiv').show();

                    $("#clickGroupCliente" + idClienteSelecionado).trigger("click");

                    var offTop = $("#cliente" + idClienteSelecionado).offset().top - 150;
                    $('html, body').scrollTop(offTop);
                    
                    tarefas.DetalharCliente($("div").find("[data-target='#groupCliente" + idClienteSelecionado + "']"));

                    setTimeout(function () {
                        $('#loadingDiv').hide();
                    }, 1000);
                }
            },
            error: function (error) {
                alert('error; ' + eval(error));
            }
        });

    }
}

$(document).ready(function () {
    tarefas = new Tarefas();

    alertify.set({
        labels: {
            ok: "Sim",
            cancel: "Não"
        }
    });

    tarefas.inicializaDatePicker();

    tarefas.SelecionarVendedor($('#idVendedorSelecionado').val());

    $('#loadingDiv')
        .hide()
        .ajaxStart(function () {
            $(this).show();
        })
        .ajaxStop(function () {
            $(this).hide();
        });

});