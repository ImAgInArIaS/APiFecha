namespace ApiBaseDatos.Resultados;

public class ResultadoBase
{
    public bool Ok {get; set;} = true;
    public string Error {get; set;}
    public string StatusCode {get; set;}
    public void SetError(string mensajeError){

        Ok = false;
        Error = mensajeError;
    }
}
