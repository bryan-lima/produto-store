function atualizarProduto(id, model) {
    $.ajax({
        method: "POST",
        url: "https://localhost:44344/Produto/Atualizar/" + id,
        data: JSON.stringify(model, null, 2)
    })
}