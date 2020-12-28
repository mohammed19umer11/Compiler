using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace CompilerConstruction
{
    class Program
    {
        static Boolean Isidentifier (String word){
            string pattern = @"(_|@)?([a-zA-z][a-zA-Z]*[_]*)";
            // string pattern = @"(_|@)?([a-zA-z]([a-zA-Z]*|))";
            Regex rg = new Regex(pattern);
            if(rg.IsMatch(word)==true){
                return true;
            }
            else {
                return false;
            }            
        } 
        static Boolean Isdigits (String word){
            Regex num = new Regex("^[0-9]+$", RegexOptions.Compiled);
            if(num.IsMatch(word)==true){
                return true;
            }
            else {
                return false;
            }            
        } 

        static Boolean IsdataType (String word){
            String [] datatype = new String [] {"int","string","String","float","double","bool","Boolean"};
            if(Array.Exists(datatype, element => element == word)){
                return true;
            }
            else {
                return false;
            }
        }

        // static void WordBreakers.ClassIdentify (String word,ArrayList words,int line){
        //     if(!(String.IsNullOrEmpty(word))){
        //         if(Isidentifier(word)){
        //             words.Add(new Token(word,line,"Identifier"));
        //         }
        //         else if(IsdataType(word)){
        //             words.Add(new Token(word,line,"Data Type")); 
        //         }
        //         else {
        //             words.Add(new Token(word,line,""));
        //         }
        //     }
        // }

        static Boolean multilineEnd (String code,int indexa,int indexb){
            if(!(indexa>=code.Length-1)&&!(indexb>=code.Length-1)){
                if(code[indexa].ToString().Equals("#")&& code[indexb].ToString().Equals("#")){
                    Console.WriteLine("Multiline Comment End");
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }

        static void Main(string[] args)
        {
           String code_a = "int a = 1;\n a/=2;\n if(a!=2 || !(a<=2 && a>0)){a++;}\n int [] array; ##umer sadsadsadas##"+
           "\nString @name = \"umer\\\t\";\n int b = a + 2;";
            String code_b = "abc5.99b.55";
 
            foreach(Token token in tokenize(code_a)){
                Console.WriteLine("TOKEN => Line No : {0}   Word = {1}  Class = {2}",token.Line,token.Word,token.Class);
            }
            // foreach(Token token in tokenize(code_b)){
            //     Console.WriteLine("TOKEN => Line No : {0}   Word = {1}  Class = {2}",token.Line,token.Word,token.Class);
            // }
        }

        static ArrayList tokenize (String code)
        {
            var words = new ArrayList();
            int line = 0;
            String temp="";
            String [] operator_1 = new String [] {"+","-"};
            String [] operator_2 = new String [] {"/","*","%"}; 
            String [] operator_3 = new String [] {"="};
            String [] operator_4 = new String [] {"<",">"};
            String [] operator_5 = new String [] {"|"};
            String [] operator_6 = new String [] {"&"};
            String [] operator_7 = new String [] {"!"};
            String [] punctuators = new String [] {",","(",")","{","}","[","]",
            " "};
            String [] punctuator_1 = new String [] {"."};
            Boolean jump=false;
            Boolean comment=false;
            Console.WriteLine(code.Length);
            for(int index=0;index<code.Length;index+=(jump==true)?2:(comment==true)?2:1){

                Console.WriteLine("Character : {0}  Index : {1}",code[index],index);
                // "+ and -"
                if(Array.Exists(operator_1, element => element == code[index].ToString())){
                    comment=false;
                    WordBreakers.ClassIdentify(temp,words,line);
                    jump=WordBreakers.addsubOperator(code,words,index,line);
                    temp="";
                }
                // "/ and *"
                else if(Array.Exists(operator_2, element => element == code[index].ToString())){
                    comment=false;
                    WordBreakers.ClassIdentify(temp,words,line);
                    temp="";
                    temp+=code[index];
                    if(!(index+1 == code.Length-1)){
                        if(Array.Exists(operator_3, element => element == code[index+1].ToString())){
                            temp+=code[index+1];
                            WordBreakers.ClassIdentify(temp,words,line);
                            temp="";
                            if(!(index+2==code.Length-1)){
                                jump=true;
                            }
                            else{
                                jump=false;
                            }
                        }
                        else{
                            WordBreakers.ClassIdentify(temp,words,line);
                            temp="";
                            jump=false;
                        }
                    }
                    else{
                        WordBreakers.ClassIdentify(temp,words,line);
                        temp="";
                        jump=false;
                    }
                }
                // "="
                else if(Array.Exists(operator_3, element => element==code[index].ToString())){
                    comment=false;
                    WordBreakers.ClassIdentify(temp,words,line);
                    temp="";
                    temp+=code[index];
                    if(!(index+1 == code.Length-1)){
                        if(Array.Exists(operator_3, element => element==code[index+1].ToString())){
                            temp+=code[index+1];
                            WordBreakers.ClassIdentify(temp,words,line);
                            temp="";
                            if(!(index+2==code.Length-1)){
                                jump=true;
                            }
                            else{
                                jump=false;
                            }
                        }
                        else{
                            WordBreakers.ClassIdentify(temp,words,line);
                            temp="";
                            jump=false;
                        }
                    } 
                    else{
                        // temp+=code[index];
                        WordBreakers.ClassIdentify(temp,words,line);
                        temp="";
                        jump=false;
                    }
                }
                // "< and >"
                else if(Array.Exists(operator_4, element => element == code[index].ToString())){
                    comment=false;
                    WordBreakers.ClassIdentify(temp,words,line);
                    temp="";
                    temp+=code[index];
                    if(!(index+1 == code.Length-1)){
                        if(Array.Exists(operator_3, element => element == code[index+1].ToString())){
                            temp+=code[index+1];
                            WordBreakers.ClassIdentify(temp,words,line);
                            temp="";
                            if(!(index+2==code.Length-1)){
                                jump=true;
                            }
                            else{
                                jump=false;
                            }
                        }
                        else {
                            WordBreakers.ClassIdentify(temp,words,line);
                            temp="";
                            jump=false;
                        }
                    }
                    else{
                        WordBreakers.ClassIdentify(temp,words,line);
                        temp="";
                        jump=false;
                    }
                }
                // |
                else if(Array.Exists(operator_5, element => element.ToString().Equals(code[index].ToString()))){
                    comment=false;
                    WordBreakers.ClassIdentify(temp,words,line);
                    temp="";
                    temp+=code[index];
                    if(!(index+1 == code.Length-1)){
                        if(Array.Exists(operator_5, element => element.ToString().Equals(code[index+1].ToString()))){
                            temp+=code[index+1];
                            WordBreakers.ClassIdentify(temp,words,line);
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
                            WordBreakers.ClassIdentify(temp,words,line);
                            temp=""; 
                            jump=false;
                        }
                    }
                    else{
                        // Return Error with line No
                        WordBreakers.ClassIdentify(temp,words,line);
                        temp="";
                        jump=false;
                    }
                }
                // "&"
                else if(Array.Exists(operator_6, element => element.ToString() == code[index].ToString())){
                    comment=false;
                    WordBreakers.ClassIdentify(temp,words,line);
                    temp="";
                    temp+=code[index];
                    if(!(index+1 == code.Length-1)){
                        if(Array.Exists(operator_6, element => element.ToString() == code[index+1].ToString())){
                            temp+=code[index+1];
                            WordBreakers.ClassIdentify(temp,words,line);
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
                            WordBreakers.ClassIdentify(temp,words,line);
                            temp="";
                            jump=false;
                        }
                    }
                    else{
                        // Return Error with line No 
                        WordBreakers.ClassIdentify(temp,words,line);
                        temp="";
                        jump=false;
                    }
                }
                // "!"
                else if (code[index].ToString().Equals("!")){
                    comment=false;
                    WordBreakers.ClassIdentify(temp,words,line);
                    temp="";
                    temp+=code[index];
                    if(!(index+1 == code.Length-1)){
                        if(Array.Exists(operator_3, element => element == code[index+1].ToString())){
                            temp+=code[index+1];
                            WordBreakers.ClassIdentify(temp,words,line);
                            temp="";
                            if(!(index+2==code.Length-1)){
                                jump=true;
                            }
                            else{
                                jump=false;
                            }
                        }
                        else{
                            WordBreakers.ClassIdentify(temp,words,line);
                            temp="";
                            jump=false;
                        }
                    }
                    else{
                        WordBreakers.ClassIdentify(temp,words,line);
                        temp="";
                        jump=false;
                    }
                }

                // Punctuators
                else if(Array.Exists(punctuators, element => element == code[index].ToString())){
                    comment=false;
                    WordBreakers.ClassIdentify(temp,words,line);
                    temp="";
                    if(!(code[index].ToString()==(" "))){
                        temp+=code[index];
                        WordBreakers.ClassIdentify(temp,words,line);
                        temp="";
                    }
                    jump=false;
                }
                
                // Point 
                else if(Array.Exists(punctuator_1, element => element == code[index].ToString())){
                    comment=false;
                    Regex num = new Regex("^[0-9]+$", RegexOptions.Compiled);
                    if(Isdigits(temp)==false){
                        Console.WriteLine("Non Numeric");
                        WordBreakers.ClassIdentify(temp,words,line);
                        temp="";
                    }
                    temp+=code[index];
                    // if(!(code[index].ToString()==(" "))){
                    //     temp+=code[index];
                    //     WordBreakers.ClassIdentify(temp,words,line);
                    //     temp="";
                    // }
                    jump=false;
                }

                // "#" Comments
                else if(code[index].ToString().Equals("#")){
                    WordBreakers.ClassIdentify(temp,words,line);
                    temp="";
                    temp+=code[index];
                    jump=false;
                    comment=true;
                    if(!(index>=code.Length-1)||!(index+1>=code.Length-1)){
                        if(code[index+1].ToString().Equals("#")){
                            temp="";
                            Console.WriteLine("Multiline Comment Start");
                            do{
                                index++;
                                Console.WriteLine(index);
                            }while(multilineEnd(code,index,index+1)==false);
                        }
                        else {
                            WordBreakers.ClassIdentify(temp,words,line);
                            temp="";
                            comment=false;
                        }
                    }
                    else {
                            WordBreakers.ClassIdentify(temp,words,line);
                            temp="";
                            comment=false;
                        }
                }

                // String with "
                else if(code[index].ToString().Equals("\"")){
                    WordBreakers.ClassIdentify(temp,words,line);
                    temp="";
                    temp+=code[index];
                    jump=false;
                    comment=true;
                    if(!(index>=code.Length-1)||!(index+1>=code.Length-1)){
                        Console.WriteLine("String Start");
                        do{
                            index++;
                            temp+=code[index];
                            Console.WriteLine(index);
                        }while(!code[index].ToString().Equals("\""));
                        WordBreakers.ClassIdentify(temp,words,line);
                        temp="";
                    }
                    else {
                        WordBreakers.ClassIdentify(temp,words,line);
                        temp="";
                        comment=false;
                    }
                }

                // String with '
                else if(code[index].ToString().Equals("'")){
                    WordBreakers.ClassIdentify(temp,words,line);
                    temp="";
                    temp+=code[index];
                    jump=false;
                    comment=true;
                    if(!(index>=code.Length-1)||!(index+1>=code.Length-1)){
                        Console.WriteLine("String Start");
                        do{
                            index++;
                            temp+=code[index];
                            Console.WriteLine(index);
                        }while(!code[index].ToString().Equals("'"));
                        WordBreakers.ClassIdentify(temp,words,line);
                        temp="";
                    }
                    else {
                        WordBreakers.ClassIdentify(temp,words,line);
                        temp="";
                        comment=false;
                    }
                }

                // Terminator
                else if(code[index].ToString()==(";")){
                    comment=false;
                    WordBreakers.ClassIdentify(temp,words,line);
                    temp="";
                    temp+=code[index];
                    WordBreakers.ClassIdentify(temp,words,line);
                    temp="";
                    jump=false;
                }

                // New line 
                else if(code[index].ToString()==("\n")){
                    comment=false;
                    WordBreakers.ClassIdentify(temp,words,line);
                    temp="";
                    line++;
                    jump=false;
                }

                // End of File 
                else if(index==code.Length-1){
                    comment=false;
                    temp+=code[index];
                    WordBreakers.ClassIdentify(temp,words,line);
                    temp="";  
                    jump=false;
                }

                else {
                    comment=false;
                    if(temp=="." && !Char.IsDigit(code[index])){
                        WordBreakers.ClassIdentify(temp,words,line);
                        temp="";
                    }
                    temp+=code[index];
                    jump=false;
                }
            }
            return words;
        }
    }
}


