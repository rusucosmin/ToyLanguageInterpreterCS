using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyLanguageInterpreterCS.model;
using ToyLanguageInterpreterCS.repository;
using ToyLanguageInterpreterCS.controller;
using ToyLanguageInterpreterCS.view;
using System.IO;

namespace ToyLanguageInterpreterCS
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            *   Lab2Ex1:
            *   v = 2;
            *   print (v)
            *
            * */
            IStmt lab2ex1 = new CompStmt(new AssignStmt("v", new ConstExp(2)), new PrintStmt(new
                    VarExp("v")));
            /*
            *   Lab2Ex2:
            *   a = 2 + 3 * 5;
            *   b = a + 1;
            *   print (b)
            *
            * */
            IStmt lab2ex2 = new CompStmt(new AssignStmt("a", new ArithExp(ArithExp.Operation.ADD, new ConstExp(2), new
                    ArithExp(ArithExp.Operation.MULTIPLY, new ConstExp(3), new ConstExp(5)))),
                    new CompStmt(new AssignStmt("b", new ArithExp(ArithExp.Operation.ADD, new VarExp("a"), new
                            ConstExp(1))), new PrintStmt(new VarExp("b"))));
            /*
            *   Lab2Ex3:
            *   a = 2 - 2;
            *   If a then v = 2 else v = 3;
            *   print (v)
            *
            * */
            IStmt lab2ex3 = new CompStmt(new AssignStmt("a", new ArithExp(ArithExp.Operation.SUBTRACT, new ConstExp(2), new
                    ConstExp(2))),
                    new CompStmt(new IfStmt(new VarExp("a"), new AssignStmt("v", new ConstExp(2)), new
                            AssignStmt("v", new ConstExp(3))), new PrintStmt(new VarExp("v"))));


            /*
            *   Lab5Ex1
            *   openRFile (var_f, "test.in");
            *   readFile (var_f, var_c); print (var_c);
            *   If var_c then readFile (var_f, var_c); print (var_c) else print (0);
            *   closeRFile (var_f)
            *
            * */
            IStmt lab5ex1 = new CompStmt(
                    new OpenRFileStmt("var_f", "test.in"),
                    new CompStmt(
                            new ReadFileStmt(new VarExp("var_f"), "var_c"),
                            new CompStmt(
                                    new PrintStmt(new VarExp("var_c")),
                                    new CompStmt(
                                            new IfStmt(
                                                    new VarExp("var_c"),
                                                    new CompStmt(
                                                        new ReadFileStmt(new VarExp("var_f"), "var_c"),
                                                        new PrintStmt(new VarExp("var_c"))
                                                    ),
                                                    new PrintStmt(new ConstExp(0))
                                            ),
                                            new CloseRFileStmt(new VarExp("var_f"))
                                    )
                            )
                    )
            );

            /*
            *   Lab5Ex2
            *   openRFile (var_f, "test.in");
            *   readFile (var_f + 2, var_c); print (var_c);
            *   If var_c then readFile (var_f, var_c); print (var_c) else print (0);
            *   closeRFile (var_f)
            * */
            IStmt lab5ex2 = new CompStmt(
                    new OpenRFileStmt("var_f", "test.in"),
                    new CompStmt(
                            new ReadFileStmt(new ArithExp(ArithExp.Operation.ADD, new VarExp("var_f"), new ConstExp(2)), "var_c"),
                            new CompStmt(
                                    new PrintStmt(new VarExp("var_c")),
                                    new CompStmt(
                                            new IfStmt(
                                                    new VarExp("var_c"),
                                                    new CompStmt(
                                                        new ReadFileStmt(new VarExp("var_f"), "var_c"),
                                                        new PrintStmt(new VarExp("var_c"))
                                                    ),
                                                    new PrintStmt(new ConstExp(0))
                                            ),
                                            new CloseRFileStmt(new VarExp("var_f"))
                                    )
                            )
                    )
            );
            TextMenu menu = new TextMenu(new MyDictionary<string, Command>(new Dictionary<string, Command>()));

            menu.addCommand(new ExitCommand("0", "exit"));
            menu.addCommand(new RunExample("1", lab2ex1.ToString(), createController(lab2ex1, "log1.txt")));
            menu.addCommand(new RunExample("2", lab2ex2.ToString(), createController(lab2ex2, "log2.txt")));
            menu.addCommand(new RunExample("3", lab2ex3.ToString(), createController(lab2ex3, "log3.txt")));
            menu.addCommand(new RunExample("4", lab5ex1.ToString(), createController(lab5ex1, "log4.txt")));
            menu.addCommand(new RunExample("5", lab5ex2.ToString(), createController(lab5ex2, "log5.txt")));

            menu.show();
       }
        static Controller createController(IStmt stmt, string log)
        {
            if(File.Exists(log))
            {
                File.Delete(log);
            }
            IRepository repo = new Repository(log);
            Controller ctrl = new Controller(repo);
            ctrl.setMain(new PrgState(stmt));
            return ctrl;
        }
    }
}
