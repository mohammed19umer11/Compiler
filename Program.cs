using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace CompilerConstruction
{
    class Program
    {
        static Boolean Isidentifier (String word){
            string pattern = @"(_|@)([a-z+A-Z]+)";
            Regex rg = new Regex(pattern);
            if(rg.IsMatch(word)==true){
                return true;
            }
            else {
                return false;
            }            
        }            
    

        static void Main(string[] args)
        {
           // String code_a = "int a = 1_\n a+=2_\n if(a==2 || a<=2 && a>0){a++_}\n int [] array_";
            String code_b = "_abc int a=1\na==3  _dfd";
            // Console.WriteLine("Hello World!");

            // String [,] keywords = new String [,] {{"int","Data Type"},{"string","Data Type"},{"float","Data Type"},
            // {"double","Data Type"},{"bool","Data Type"}}; 
            foreach(Token token in tokenize(code_b)){
                Console.WriteLine("TOKEN => Line No : {0}   Word = {1}  Class = {2}",token.Line,token.Word,token.Class);
            }
        }

        static ArrayList tokenize (String code)
        {
            var words = new ArrayList();
            int line = 0;
            String temp="";
            String [] operator_1 = new String [] {"+","-"};
            String [] operator_2 = new String [] {"/","*",}; 
            String [] operator_3 = new String [] {"="};
            String [] operator_4 = new String [] {"<",">"};
            String [] operator_5 = new String [] {"|"};
            String [] operator_6 = new String [] {"&"};
            String [] operator_7 = new String [] {"!"};
            String [] punctuators = new String [] {"\"","'",".",",","(",")","{","}","[","]",
            "/","#"," "};
            Boolean jump=false;
            Console.WriteLine(code.Length);
            for(int index=0;index<code.Length;index+=(jump==true)?2:1){
                
                // "+ and -"
                if(Array.Exists(operator_1, element => element == code[index].ToString())){
                    if(!String.IsNullOrEmpty(temp)){
                        words.Add(new Token(temp,line,"")); 
                        temp="";
                        temp+=code[index];
                    if(!(index+1 == code.Length-1)){
                        if(Array.Exists(operator_3, element => element == code[index+1].ToString())){
                            temp+=code[index+1];
                            words.Add(new Token(temp,line,""));
                            temp="";
                            if(!(index+2==code.Length-1)){
                                jump=true;
                            }
                            else{
                                jump=false;
                            }
                        }
                        else if(code[index+1].Equals("+")){
                            temp+=code[index+1];
                            words.Add(new Token(temp,line,""));
                            temp="";
                            if(!(index+2==code.Length-1)){
                                jump=true;
                            }
                            else{
                                jump=false;
                            }
                        }
                        else if(code[index+1].Equals("-")){
                            temp+=code[index+1];
                            words.Add(new Token(temp,line,""));
                            temp="";
                            if(!(index+2==code.Length-1)){
                                jump=true;
                            }
                            else{
                                jump=false;
                            }
                        }
                        else{
                            words.Add(new Token(temp,line,""));
                            temp="";
                            jump=false;
                        }
                    }
                    else{
                        words.Add(new Token(temp,line,""));
                        temp="";
                        jump=false;
                    } 
                    }
                }
                // "/ and *"
                else if(Array.Exists(operator_2, element => element == code[index].ToString())){
                    if(!String.IsNullOrEmpty(temp)){
                        words.Add(new Token(temp,line,""));
                        temp="";
                        temp+=code[index];
                    if(!(index+1 == code.Length-1)){
                        if(Array.Exists(operator_3, element => element == code[index+1].ToString())){
                            temp+=code[index+1];
                            words.Add(new Token(temp,line,""));
                            temp="";
                            if(!(index+2==code.Length-1)){
                                jump=true;
                            }
                            else{
                                jump=false;
                            }
                        }
                        else if(code[index+1].Equals("/")){
                            temp+=code[index+1];
                            words.Add(new Token(temp,line,""));
                            temp="";
                            if(!(index+2==code.Length-1)){
                                jump=true;
                            }
                            else{
                                jump=false;
                            }
                        }
                        else if(code[index+1].Equals("*")){
                            temp+=code[index+1];
                            words.Add(new Token(temp,line,""));
                            temp="";
                            if(!(index+2==code.Length-1)){
                                jump=true;
                            }
                            else{
                                jump=false;
                            }
                        }
                        else{
                            words.Add(new Token(temp,line,""));
                            temp="";
                            jump=false;
                        }
                    }
                    else{
                        words.Add(new Token(temp,line,""));
                        temp="";
                        jump=false;
                    }
                }
                }
                // "="
                else if(Array.Exists(operator_3, element => element==code[index].ToString())){
                    if(!String.IsNullOrEmpty(temp)){
                        words.Add(new Token(temp,line,""));
                        temp="";
                        temp+=code[index];
                    if(!(index+1 == code.Length-1)){
                        if(Array.Exists(operator_3, element => element==code[index+1].ToString())){
                            temp+=code[index+1];
                            words.Add(new Token(temp,line,""));
                            temp="";
                            if(!(index+2==code.Length-1)){
                                jump=true;
                            }
                            else{
                                jump=false;
                            }
                        }
                        else{
                            words.Add(new Token(temp,line,""));
                            temp="";
                            jump=false;
                        }
                    } 
                    else{
                        temp+=code[index];
                        words.Add(new Token(temp,line,""));
                        temp="";
                        jump=false;
                    }
                }
                }
                // "< and >"
                else if(Array.Exists(operator_4, element => element == code[index].ToString())){
                    if(!String.IsNullOrEmpty(temp)){
                        words.Add(new Token(temp,line,""));
                        temp="";
                        temp+=code[index];
                    if(!(index+1 == code.Length-1)){
                        if(Array.Exists(operator_3, element => element == code[index+1].ToString())){
                            temp+=code[index+1];
                            words.Add(new Token(temp,line,""));
                            temp="";
                            if(!(index+2==code.Length-1)){
                                jump=true;
                            }
                            else{
                                jump=false;
                            }
                        }
                        else {
                            words.Add(new Token(temp,line,""));
                            temp="";
                            jump=false;
                        }
                    }
                    else{
                        words.Add(new Token(temp,line,""));
                        temp="";
                        jump=false;
                    }
                }
                }
                // |
                else if(Array.Exists(operator_5, element => element == code[index].ToString())){
                    if(!String.IsNullOrEmpty(temp)){
                        words.Add(new Token(temp,line,""));
                        temp="";
                        temp+=code[index];
                    if(!(index+1 == code.Length-1)){
                        if(Array.Exists(operator_5, element => element == code[index+1].ToString())){
                            temp+=code[index+1];
                            words.Add(new Token(temp,line,""));
                            temp="";
                            if(!(index+2==code.Length-1)){
                                jump=true;
                            }
                            else{
                                jump=false;
                            }
                        }
                        else{
                        // Return Error with line No
                            words.Add(new Token(temp,line,""));
                            temp=""; 
                            jump=false;
                        }
                    }
                    else{
                        // Return Error with line No
                        words.Add(new Token(temp,line,""));
                        temp="";
                        jump=false;
                    }
                }
                }
                // "&"
                else if(Array.Exists(operator_6, element => element == code[index].ToString())){
                    if(!String.IsNullOrEmpty(temp)){
                        words.Add(new Token(temp,line,""));
                        temp="";
                        temp+=code[index];
                    if(!(index+1 == code.Length-1)){
                        if(Array.Exists(operator_6, element => element == code[index].ToString())){
                            temp+=code[index+1];
                            words.Add(new Token(temp,line,""));
                            temp="";
                            if(!(index+2==code.Length-1)){
                                jump=true;
                            }
                            else{
                                jump=false;
                            }
                        }
                        else{
                        // Return Error with line No 
                            words.Add(new Token(temp,line,""));
                            temp="";
                            jump=false;
                        }
                    }
                    else{
                        // Return Error with line No 
                        words.Add(new Token(temp,line,""));
                        temp="";
                        jump=false;
                    }
                }
                }
                // "!"

                // Punctuators
                else if(Array.Exists(punctuators, element => element == code[index].ToString())){
                    if(!String.IsNullOrEmpty(temp)){
                        if(Isidentifier(temp)){
                            words.Add(new Token(temp,line,"Identifier"));   
                            }
                        else {
                            words.Add(new Token(temp,line,""));
                        }
                        temp="";
                        if(!(code[index].ToString()==(" "))){
                            temp+=code[index];
                            words.Add(new Token(temp,line,""));
                            temp="";
                        }
                    }  
                    jump=false;
                }
                else if(code[index].ToString()==(";")){
                   if(!String.IsNullOrEmpty(temp)){
                        words.Add(new Token(temp,line,""));
                        temp="";
                        temp+=code[index];
                        words.Add(new Token(temp,line,""));
                        temp="";
                    } 
                   jump=false;
                }
                else if(code[index].ToString()==("\n")){
                    if(!String.IsNullOrEmpty(temp)){
                        words.Add(new Token(temp,line,""));
                        temp="";
                    }
                    line++;
                    jump=false;
                }
                else if(index==code.Length-1){
                    if(!String.IsNullOrEmpty(temp)){
                        if(Isidentifier(temp)){
                            temp+=code[index];
                            words.Add(new Token(temp,line,"Identifier"));   
                            }
                        else {
                            temp+=code[index];
                            words.Add(new Token(temp,line,""));
                        }
                        temp="";
                    }  
                    jump=false;
                }
                else {
                    temp+=code[index];
                    jump=false;
                }
            }
            return words;
        }
    }
}


