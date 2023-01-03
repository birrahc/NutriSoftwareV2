﻿

function AbrirModalParaCadastro() {

    $.ajax({
        url: '/Paciente/Create',
        type: 'GET',
        async: true,
        success: function (response) {
            $("#formularioPaciente").empty();
            $("#formularioPaciente").append(response);
            $('#modalPaciente').modal('show')
            
        },
        error: function (response) {
            toastr.error("Houve um erro ao abrir formulário." + response, "Error");
        }
    });
}

function AbrirFormulariEdicao(value)
{
    window.value = value;
   
    $.ajax({
        url: '/Paciente/Edit',
        type: 'GET',
        data: {Id: window.value},
        async: true,
        success: function (response) {
            $("#formularioPaciente").empty();
            $("#formularioPaciente").append(response);
            $('#modalPaciente').modal('show')
        },
        error: function (response) {
            toastr.error("Houve um erro na abrir formulario de Edição." + response, "Error");
        }
    });
}

function cadastrarPaciente() {

    var dados = $("#formularioCadastrarPaciente").serialize();
    var action = $('input[ident-paciente ="pacienteId"]').val() > 0 ? "Edit" : "Create";
    var mensagem = action == "Edit" ? "Dados do paciente editados com sucesso" : "Paciente cadastrado com sucesso";

    $.ajax({
        url: '/Paciente/'+action,
        type: 'POST',
        data: dados,
        async: true,
        success: function (response) {
            $("#Conteudo").empty();
            $("#Conteudo").append(response);
            $('#modalPaciente').modal('hide')
            toastr.success(mensagem, "Sucesso");
        },
        error: function (response) {
            toastr.error(mensagem, "Error");
        }
    });
}

function ExcluirPaciente(value)
{
    if (value > 0) {
        Swal.fire({
            title: 'Deseja realmente deletar esse paciente ?',
            //text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sim'

        }).then((result) => {
            if (result.value) {

                $.ajax({
                    url: '/Paciente/Delete',
                    type: 'POST',
                    data: { Id: value },
                    async: true,
                    success: function (response) {
                        $("#Conteudo").empty();
                        $("#Conteudo").append(response);
                        toastr.success("Paciente excluido com sucesso.", "Sucesso");
                    },
                    error: function (response) {
                        toastr.error("Erro ao tentar excluir " + response, "Error");
                    }
                });
            }
        });
    }

   
}

function AbrirModalParaAvaliacao(value) {
    window.value = value;
    $.ajax({
        url: '/Paciente/CadastraAvaliacaoPaciente',
        type: 'GET',
        data: { pacienteId: window.value },
        async: true,
        success: function (response) {
            $("#formularioAvaliacao").empty();
            $("#formularioAvaliacao").append(response);
            $('input[mask="formAval"]').mask("00,0", { reverse: false });
            $('#modalAvaliacao').modal('show')

        },
        error: function (response) {
            toastr.error("Houve um erro ao abrir formulário." + response, "Error");
        }

    });
}

function AbrirModalParaEdicaoAvaliacao(id) {
    window.id = id;
    $.ajax({
        url: '/Paciente/EditarAvaliacaoPaciente',
        type: 'GET',
        data: { Id: window.id },
        async: true,
        success: function (response) {
            $("#formularioAvaliacao").empty();
            $("#formularioAvaliacao").append(response);
            $(".avalAnterior").hide();
            $('#modalAvaliacao').modal('show')
            $('input[mask="formAval"]').mask("00,0", { reverse: false });
        },
        error: function (response) {-
            toastr.error("Houve um erro ao abrir formulário." + response, "Error");
        }
    });
}

function CadastrarEditarAvaliacao() {
    var dados = $("#formularioCadastrarEditarAvaliacao").serialize();
    var action = $("#avaliacaoId").val() < 1 ? "CadastraAvaliacaoPaciente" : "EditarAvaliacaoPaciente";
    var mensagem = action == "CadastraAvaliacaoPaciente" ? "Avaliação cadastrada com sucesso." : "Avaliação atualizada com sucesso"
    

    $.ajax({
        url: '/Paciente/'+ action,
        type: 'POST',
        data: dados,
        async: true,
        success: function (response) {
            $("#conteudoAvaliacao").empty();
            $("#conteudoAvaliacao").append(response);
            $('#modalAvaliacao').modal('hide')
            toastr.success(mensagem, "Sucesso");
        },
        error: function (response) {
            toastr.error("Houve um erro ao abrir formulário." + response, "Error");
        }
    });
}

function pesquisaPaciente()
{
    var pesquisa = $("#txtPesquisa").val();
    $.ajax({
        url: '/Paciente/PesquisaPaciente',
        type: 'POST',
        data: { pesquisaPaciente: pesquisa },
        async: true,
        success: function (response) {
            $("#listaDepacientes").empty();
            $("#listaDepacientes").append(response);
        },
        error: function (response) {
            toastr.error("Houve um erro ao pesquisar." + response, "Error");
        }
    });
}

function abrirModalObservacao(value)
{
    window.value = value;
    $.ajax({
        url: '/Paciente/CadastrarAnotacoesPaciente',
        type: 'GET',
        data: { pacienteId: window.value },
        async: true,
        success: function (response) {
            $("#formularioObservacaoPaciente").empty();
            $("#formularioObservacaoPaciente").append(response);
            //$('.form-control').mask("00,00", { reverse: true });
            $('#modalObservacaoPaciente').modal('show');

        },
        error: function (response) {
            toastr.error("Houve um erro ao abrir formulário." + response, "Error");
        }
    });

}

function EditarAnotacaoPaciente(value) {
   
    $.ajax({
        url: '/Paciente/EditarAnotacoesPaciente',
        type: 'GET',
        data: { anotacaoId: value },
        async: true,
        success: function (response) {
            $("#formularioObservacaoPaciente").empty();
            $("#formularioObservacaoPaciente").append(response);
            $('#modalObservacaoPaciente').modal('show');
        },
        error: function (response) {
            toastr.error("Erro na operação", "Error");
        }
    });
}

function CadastrarEditarAnotacoesPaciente()
{
    var dados = $("#formObservacaoPaciente").serialize();
    var action = $('input[ident-anotacao ="anotacaoId"]').val() > 0 ? "EditarAnotacoesPaciente" : "CadastrarAnotacoesPaciente";
    var mensagem = action == "EditarAnotacoesPaciente" ? "Anotações editadas com sucesso" : "Anotações cadastradas com sucesso";
    
    $.ajax({
        url: '/Paciente/' + action,
        type: 'POST',
        data: dados,
        async: true,
        success: function (response) {
            $("#observacoes").empty();
            $("#observacoes").append(response);
            $('#modalObservacaoPaciente').modal('hide')
            toastr.success(mensagem, "Sucesso");
        },
        error: function (response) {
            toastr.error("Erro na operação", "Error");
        }
    });

}

function deletarObservacaoPaciente(value)
{
    if (value > 0) {
        Swal.fire({
            title: 'Deseja realmente deletar essa anotação ?',
            //text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sim'

        }).then((result) => {
            if (result.value) {

                $.ajax({
                    url: '/Paciente/DeletarAnotacao',
                    type: 'POST',
                    data: { anotacaoId: value },
                    async: false,
                    success: function (response) {

                        $("#observacoes").empty();
                        $("#observacoes").append(response);
                        toastr.success("Anotação excluida com sucesso.", "Sucesso");
                    },
                    error: function (response) {
                        alert("Houve um erro ao deletar.");
                    }
                });
            }
        });
    }

}

