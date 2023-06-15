void Excluir(tp_no lista, string nome_procurado, ref tp_no atual, ref tp_no anterior)
{
    Consulta(lista, nome_procurado, ref atual, ref anterior);
        if (atual != null){
            if(atual == lista){
                lista = lista.prox;
                atual.prox = null;
            }
            else if(atual.prox == null){
                anterior.prox = null;
            }
            else{
                anterior.prox = atual.prox;
                atual.prox = null;
            }
            System.Console.WriteLine("Removido com sucesso.");
            Console.ReadKey();
        }
        else{
            System.Console.WriteLine("Nome não encontrado");
            Console.ReadKey();
        }
}
void Insere(ref tp_no t, string n, string i, string w)
{
    tp_no no = new tp_no();
    no.nome = n;
    no.idade = i;
    no.whats = w;
    if (t != null)
        no.prox = t;
    t = no;
}

void Consulta(tp_no l, string np, ref tp_no atu, ref tp_no ant)
{
    ant = null;
    atu = l;
    while(atu != null && np!= atu.nome){
        ant = atu;
        atu = atu.prox;
    }
}

void Exibir(tp_no l)
{
    tp_no aux;
    aux = l;
    if(aux != null){
        while (aux != null){
            System.Console.WriteLine($"Nome: {aux.nome}");
            System.Console.WriteLine($"Idade: {aux.idade}");
            System.Console.WriteLine($"Whatsapp: {aux.whats}");
            aux = aux.prox;
        }
        Console.ReadKey();
    }
    else{
        Console.WriteLine("Sem dados para exibir.");
        Console.ReadKey();
    }
}

int menu()
{
    Console.Clear();
    System.Console.WriteLine("###### Menu ######");
    System.Console.WriteLine("1 - Inserir");
    System.Console.WriteLine("2 - Alterar");
    System.Console.WriteLine("3 - Excluir");
    System.Console.WriteLine("4 - Exibir");
    System.Console.WriteLine("5 - Sair");
    System.Console.WriteLine("____________________");
    System.Console.WriteLine("Informe a opção desejada: ");
    int opcao = Convert.ToInt32(Console.ReadLine());
    return opcao;
}

//Principal
tp_no lista = null;
tp_no anterior = null;
tp_no atual = null;
string nome;
string idade;
string whats;

int op = menu();
Console.WriteLine();
while(op  >= 1 && op <= 4){
    string nome_procurado;
    if(op == 1){//Conheça os dados
        System.Console.WriteLine("Informe seu nome: ");
        nome = Console.ReadLine();
        System.Console.WriteLine("Informe sua idade: ");
        idade = Console.ReadLine();
        System.Console.WriteLine("Informe seu Whatsapp: ");
        whats = Console.ReadLine();
        Insere(ref lista, nome, idade, whats);
        System.Console.WriteLine();
    }
    else if(op == 2){
        System.Console.WriteLine("Qual nome você procura ?");
        nome_procurado = Console.ReadLine();
        Consulta(lista, nome_procurado, ref atual, ref anterior);
        if(atual != null){   
            System.Console.WriteLine("Dados atuais");
            System.Console.WriteLine("Nome: " + atual.nome);
            System.Console.WriteLine("Idade: " + atual.idade);
            System.Console.WriteLine("Whatsapp: " + atual.whats);
            System.Console.WriteLine("Digite os novos dados");
            Console.Write("Nome: ");
            atual.nome = Console.ReadLine();
            Console.Write("Idade: ");
            atual.idade = Console.ReadLine();
            Console.Write("Whatsapp: ");
            atual.whats = Console.ReadLine();
        }
        else{
            System.Console.WriteLine("Não encontrado.");
            Console.ReadKey();
        }
        System.Console.WriteLine();
    }   
    else if(op == 3){
    System.Console.WriteLine("Qual nome você procura ?");
    nome_procurado = Console.ReadLine();
    Excluir(lista, nome_procurado, ref atual, ref anterior);
    }
    else if(op == 4){
        Exibir(lista);
    }
    op = menu();
}

class tp_no
{
    public string nome, idade, whats;
    public tp_no prox;
}