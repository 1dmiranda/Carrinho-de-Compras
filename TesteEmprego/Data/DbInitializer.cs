using TesteEmprego.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteEmprego.Data
{
    public class DbInitializer
    {
        public static void Initialize(BDContext context)
        {
            context.Database.EnsureCreated();

            if (context.Produtos.Any())
            {
                return;   // DB has been seeded
            }

            //Simulando um usuário já cadastrado e uma compra
            var usuario = new Usuario { Nome = "Saulo", Email = "teste@teste.com", Cpf = "445623145623" };
            context.Usuarios.Add(usuario);
            context.SaveChanges();

            var produto4 = new Produto { Nome = "produto4", Preco = 100 };
            var produto1 = new Produto { Nome = "produto1", Preco = 300 };
            var produto2 = new Produto { Nome = "produto2", Preco = 500 };
            var produto3 = new Produto { Nome = "produto3", Preco = 900 };
            var produtos = new[] { produto1, produto2, produto3, produto4 };
            context.Produtos.AddRange(produtos);
            context.SaveChanges();

            var pedido = new Pedido { UsuarioId = usuario.Id, Data = DateTime.Now };
            context.Pedidos.Add(pedido);
            context.SaveChanges();

            var produtosComprados = new List<Produto> { produto1, produto3 };

            //Salvando cada item de Pedido
            foreach (var prod in produtosComprados)
            {
                var pedidoItem = new PedidoItem { PedidoId = pedido.Id, ProdutoId = prod.Id };
                context.Itens.Add(pedidoItem);
                context.SaveChanges();
            }

        }
    }
}
