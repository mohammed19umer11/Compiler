using System;
using System.Collections;
using System.Text.RegularExpressions;


namespace CompilerConstruction{

    abstract class WordBreakers{

        public static Boolean isPlusMinusOperator (String word) {
            if(word.Equals("+")||word.Equals("-")){
                return true;
            }
            else {
                return false;
            }
        }

        public static Boolean isMultiplyDivideModOperator (String word) {
            if(word.Equals("+")||word.Equals("-")||word.Equals("%")){
                return true;
            }
            else {
                return false;
            }
        }

        public static Boolean isAssingmentOperator (String word){
            String [] assigmentoperators = new String [] {"=","+=","-+","/=","*=","%="};
            if(Array.Exists(assigmentoperators, element => element == word)){
                return true;
            }
            else {
                return false;
            }
        }

        public static Boolean isRelationalOperator (String word){
            String [] relationaloperators = new String [] {"<",">","<=",">=","==","!="};
            if(Array.Exists(relationaloperators, element => element == word)){
                return true;
            }
            else {
                return false;
            }
        }

        public static Boolean isAndOperator (String word){
            if(word.Equals("&&")){
                return true;
            }
            else {
                return false;
            }
        }

        public static Boolean isOrOperator (String word){
            if(word.Equals("||")){
                return true;
            }
            else {
                return false;
            }
        }

        public static Boolean isIdentifier (String word){
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

        public static Boolean isKeyword (String word){
            String [] keywords = new String [] {"abstract","break","class","const","continue","do","while",
            "enum","true","false","finally","for","foreach","if","else","in","interface","namespace","new",
            "null","private","protected","public","return","sealed","static","switch","case","this","throw",
            "try","catch","using","void"};
            if(Array.Exists(keywords, element => element == word)){
                return true;
            }
            else {
                return false;
            }
        }       

        public static Boolean isDataType (String word){
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
                if(isAssingmentOperator(word)){
                    words.Add(new Token(word,line,"Assigment Operator")); 
                }
                else if(isRelationalOperator(word)){
                    words.Add(new Token(word,line,"Relational Operator")); 
                }
                else if(isAndOperator(word)){
                    words.Add(new Token(word,line,"And Operator")); 
                }
                else if(isOrOperator(word)){
                    words.Add(new Token(word,line,"Or Operator")); 
                }
                else if(word.Equals("!")){
                    words.Add(new Token(word,line,"Not Operator"));
                }
                else if(isIdentifier(word)){
                    if(isDataType(word)){
                        words.Add(new Token(word,line,"Data Type"));
                    } 
                    else if(isKeyword(word)){
                        words.Add(new Token(word,line,"Keyword"));
                    } 
                    else {
                        words.Add(new Token(word,line,"Identifier"));
                    }  
                }
                else {
                    words.Add(new Token(word,line,"invalid"));
                }
            }
        }
        public static Boolean addsubOperator(String code, ArrayList words, int index, int line){
            String temp="";
            temp+=code[index];
            if(!(index+1 == code.Length-1)){
                if(code[index+1].ToString().Equals("=")){
                    temp+=code[index+1];
                    ClassIdentify(temp,words,line);
                    if(!(index+2==code.Length-1)){
                        return true;
                    }
                    else{
                        return false;
                    }
                }
                else if(code[index+1].ToString().Equals("+")){
                    temp+=code[index+1];
                    ClassIdentify(temp,words,line);
                    if(!(index+2==code.Length-1)){
                        return true;
                    }
                    else{
                        return false;
                    }
                }
                else if(code[index+1].ToString().Equals("-")){
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
        }
    }
}