

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
    window.value = value;
    $.ajax({
        url: '/Paciente/Delete',
        type: 'POST',
        data: {Id: window.value},
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
            //$('.form-control').mask("00,00", { reverse: true });
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
