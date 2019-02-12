.assembly ThrowerLib { }

.class public Thrower {

     .method static void Main() {    
         .entrypoint     
         ret
     }

     .method static public void ThrowException( ) {
         ldstr "Standard Exception thrown."
         newobj instance void [mscorlib]System.Exception::.ctor(string)
         throw
         ret
     }

     .method static public void ThrowString( ) {
         ldstr "String thrown as exception.\n.NET 2.0 and later wraps this as a standard exception.\n.NET 1.1 this exception cannot be caught with Catch(Exception) {}, only with Catch {}"
         throw
         ret
     }
}
