using System;

namespace CompilerConstruction{
    class Token {
        public String Word
        {
            get;
        }
        public int Line
        {
            get;
        }
        public String Class
        {
            get;
        }
    public Token (){
            
        }
        public Token (String Word,int Line,String Class){
            this.Word=Word;
            this.Line=Line;
            this.Class=Class;
        }
    }
}