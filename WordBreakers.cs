using System;
using System.Collections;
using System.Text.RegularExpressions;


namespace CompilerConstruction{

    abstract class WordBreakers{

        public static String [] operator_3 = new String [] {"="};

        public static Boolean Isidentifier (String word){
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
        public static Boolean IsdataType (String word){
            String [] datatype = new String [] {"int","string","String","float","double","bool","Boolean"};
            if(Array.Exists(datatype, element => element == word)){
                return true;
            }
            else {
                return false;
            }
        }

        public static void ClassIdentify (String word,ArrayList words,int line){
            if(!(String.IsNullOrEmpty(word))){
                if(Isidentifier(word)){
                    words.Add(new Token(word,line,"Identifier"));
                }
                else if(IsdataType(word)){
                    words.Add(new Token(word,line,"Data Type")); 
                }
                else {
                    words.Add(new Token(word,line,""));
                }
            }
        }
        public static Boolean addsubOperator(String code, ArrayList words, int index, int line){
//            if(Array.Exists(operator_1, element => element == code[index].ToString())){
//                    comment=false;
//                    ClassIdentify(temp,words,line);
//                    temp="";
            String temp="";
            temp+=code[index];
            if(!(index+1 == code.Length-1)){
                if(Array.Exists(operator_3, element => element == code[index+1].ToString())){
                    temp+=code[index+1];
                    ClassIdentify(temp,words,line);
                    if(!(index+2==code.Length-1)){
                        return true;
                    }
                    else{
                        return false;
                    }
                }
                else if(code[index+1].Equals("+")){
                    temp+=code[index+1];
                    ClassIdentify(temp,words,line);
                    if(!(index+2==code.Length-1)){
                        return true;
                    }
                    else{
                        return false;
                    }
                }
                else if(code[index+1].Equals("-")){
                    temp+=code[index+1];
                    ClassIdentify(temp,words,line);
                    if(!(index+2==code.Length-1)){
                        return true;
                    }
                    else{
                        return false;
                    }
                }
                else{
                    ClassIdentify(temp,words,line);
                    return false;
                }
            }
            else{
                ClassIdentify(temp,words,line);
                return false;
             } 
//                }
        }
    }
}