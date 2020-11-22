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

        public Token (String Word,int Line){
            this.Word=Word;
            this.Line=Line;
        }
    }
}