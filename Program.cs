﻿using System;
using System.Collections;

namespace CompilerConstruction
{
    class Program
    {
        static void Main(string[] args)
        {
            String code_a = "int a = 1_\n a+=2_\n if(a==2 || a<2 && a>0){}";
            String code_b = "int a=1_";
            // Console.WriteLine("Hello World!");

            // String [,] keywords = new String [,] {{"int","Data Type"},{"string","Data Type"},{"float","Data Type"},
            // {"double","Data Type"},{"bool","Data Type"}}; 
            foreach(Token token in tokenize(code_a)){
                Console.WriteLine("TOKEN => Line No : {0}   Word = {1}",token.Line,token.Word);
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
            Boolean jump;
            for(int index=0;index<code.Length-1;index+=(jump)?2:1){
                jump=false;
                // "+ and -"
                if(Array.Exists(operator_1, element => code[index].ToString() == element)){
                    if(!String.IsNullOrEmpty(temp)){
                        words.Add(new Token(temp,line)); 
                        temp="";
                        temp+=code[index];
                    if(!(index+1 == code.Length-1)){
                        if(Array.Exists(operator_3, element => code[index+1].ToString() == element)){
                            temp+=code[index+1];
                            words.Add(new Token(temp,line));
                            temp="";
                            jump=true;
                        }
                        else if(code[index+1].ToString()=="+"){
                            temp+=code[index+1];
                            words.Add(new Token(temp,line));
                            temp="";
                            jump=true;
                        }
                        else if(code[index+1].ToString()=="-"){
                            temp+=code[index+1];
                            words.Add(new Token(temp,line));
                            temp="";
                            jump=true;
                        }
                        else{
                            words.Add(new Token(temp,line));
                            temp="";
                        }
                    }
                    // else{
                    //     words.Add(new Token(temp,line));
                    //     temp="";
                    // } 
                }
                }
                // "/ and *"
                else if(Array.Exists(operator_2, element => code[index].ToString() == element)){
                    if(!String.IsNullOrEmpty(temp)){
                    words.Add(new Token(temp,line));
                    temp="";
                    temp+=code[index];
                    if(!(index+1 == code.Length-1)){
                        if(Array.Exists(operator_3, element => code[index+1].ToString() == element)){
                            temp+=code[index+1];
                            words.Add(new Token(temp,line));
                            temp="";
                            jump=true;
                        }
                        else if(code[index+1].ToString()=="/"){
                            temp+=code[index+1];
                            words.Add(new Token(temp,line));
                            temp="";
                            jump=true;
                        }
                        else if(code[index+1].ToString()=="*"){
                            temp+=code[index+1];
                            words.Add(new Token(temp,line));
                            temp="";
                            jump=true;
                        }
                        else{
                            words.Add(new Token(temp,line));
                            temp="";
                        }
                    }
                    // else{
                    //     words.Add(new Token(temp,line));
                    //     temp="";
                    // }
                }
                }
                // "="
                else if(Array.Exists(operator_3, element => code[index].ToString() == element)){
                    if(!String.IsNullOrEmpty(temp)){
                        words.Add(new Token(temp,line));
                        temp="";
                        temp+=code[index];
                    if(!(index+1 == code.Length-1)){
                        if(Array.Exists(operator_3, element => code[index+1].ToString() == element)){
                            temp+=code[index+1];
                            words.Add(new Token(temp,line));
                            temp="";
                            jump=true;
                        }
                        else{
                            words.Add(new Token(temp,line));
                            temp="";
                        }
                    } 
                    // else{
                    //     words.Add(new Token(temp,line));
                    //     temp="";
                    // }
                }
                }
                // "< and >"
                else if(Array.Exists(operator_4, element => code[index].ToString() == element)){
                    if(!String.IsNullOrEmpty(temp)){
                        words.Add(new Token(temp,line));
                        temp="";
                        temp+=code[index];
                    if(!(index+1 == code.Length-1)){
                        if(Array.Exists(operator_3, element => code[index+1].ToString() == element)){
                            temp+=code[index+1];
                            words.Add(new Token(temp,line));
                            temp="";
                            jump=true;
                        }
                        else{
                            words.Add(new Token(temp,line));
                            temp="";
                        }
                    }
                    // else{
                    //     words.Add(new Token(temp,line));
                    //     temp="";
                    // }
                }
                }
                // |
                else if(Array.Exists(operator_5, element => code[index].ToString() == element)){
                    if(!String.IsNullOrEmpty(temp)){
                        words.Add(new Token(temp,line));
                        temp="";
                        temp+=code[index];
                    if(!(index+1 == code.Length-1)){
                        if(Array.Exists(operator_5, element => code[index+1].ToString() == element)){
                            temp+=code[index+1];
                            words.Add(new Token(temp,line));
                            temp="";
                            jump=true;
                        }
                        else{
                        // Return Error with line No 
                        }
                    }
                    else{
                        // Return Error with line No
                    }
                }
                }
                // "&"
                else if(Array.Exists(operator_6, element => code[index].ToString() == element)){
                    if(!String.IsNullOrEmpty(temp)){
                        words.Add(new Token(temp,line));
                        temp="";
                        temp+=code[index];
                    if(!(index+1 == code.Length-1)){
                        if(Array.Exists(operator_6, element => code[index+1].ToString() == element)){
                            temp+=code[index+1];
                            words.Add(new Token(temp,line));
                            temp="";
                            jump=true;
                        }
                        else{
                        // Return Error with line No 
                        }
                    }
                    else{
                        // Return Error with line No 
                    }
                }
                }
                // "!"

                // Punctuators
                else if(Array.Exists(punctuators, element => code[index].ToString() == element)){
                    if(!String.IsNullOrEmpty(temp)){
                        words.Add(new Token(temp,line));
                        temp="";
                        if(!(code[index].ToString() == " ")){
                            temp+=code[index];
                            words.Add(new Token(temp,line));
                            temp="";
                        }
                    }
                    // else {
                    //     words.Add(new Token(temp,line));
                    //     temp="";
                    // }
                    
                }
                else if(code[index].ToString() == "_"){
                   if(!String.IsNullOrEmpty(temp)){
                        words.Add(new Token(temp,line));
                        temp="";
                        temp+=code[index];
                        words.Add(new Token(temp,line));
                        temp="";
                    } 
                    // else{
                    //     words.Add(new Token(temp,line));
                    //     temp="";
                    // } 
                }
                else if(code[index].ToString() == "\n"){
                    line++;
                }
                else {
                    temp+=code[index];
                }
            }
            return words;
        }
    }
}