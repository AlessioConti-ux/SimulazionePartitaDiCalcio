using System.Diagnostics.Tracing;

namespace SimulazionePartitaCalcio
{
    internal class Program
    {

        static void scuadraGen(int[] titolari1, int[] titolari2, int[] panchina1, int[] panchina2)
        {

            Console.WriteLine("scuadra n.1");
            for (int i = 0; i < titolari1.Length; i++)
            { //genera titolari 1

                Random rng = new Random();

                titolari1[i] = rng.Next(30, 101);

                Console.WriteLine(titolari1[i]);

            }

            Console.WriteLine("scuadra n.2");
            for (int i = 0; i < titolari2.Length; i++)
            { //genera titolari 2

                Random rng = new Random();

                titolari2[i] = rng.Next(30, 101);

                Console.WriteLine(titolari2[i]);

            }

            Console.WriteLine("panchinari scuadra n.1");
            for (int i = 0; i < panchina1.Length; i++)
            { //genera panchina 1

                Random rng = new Random();

                panchina1[i] = rng.Next(30, 101);

                Console.WriteLine(panchina1[i]);

            }

            Console.WriteLine("panchinari scuadra n.2");
            for (int i = 0; i < panchina2.Length; i++)
            { //genera panchina 2

                Random rng = new Random();

                panchina2[i] = rng.Next(30, 101);

                Console.WriteLine(panchina2[i]);

            }

        }

        static void Gol(ref int potenzaS1, ref int potenzaS2, ref int golS1, ref int golS2, int[] titolari1, int[] titolari2)
        { //funzione gol


            //calcolo possibilita delle 2 squadre di fare gol
            int posS1 = potenzaS1 * 10 / (potenzaS1 + potenzaS2);

            int posS2 = potenzaS2 * 10 / (potenzaS1 + potenzaS2);

            Random rng = new Random();
            int gol = rng.Next(1, 11); //genera un numero da 1 a 10 per vedere quale squadra segna

            if (gol <= posS1)
            {

                Console.WriteLine("La scquadra 1 ha segnato");
                golS1 = golS1 + 1;

                for (int i = 0; i < titolari1.Length; i++)
                {

                    titolari1[i] = titolari1[i] + 5; //aumenta la potenza dei titolari della scquadra che ha segnato

                }

            }
            else
            {

                Console.WriteLine("La scquadra 2 ha segnato");
                golS2 = golS2 + 1;

                for (int i = 0; i < titolari2.Length; i++)
                {

                    titolari2[i] = titolari2[i] + 5; //aumenta la potenza dei titolari della scquadra che ha segnato

                }


            }

        }//fine funzione gol

        static void infortunio()
        { //funzione infortunio

            Random rng = new Random();

            int inf = rng.Next(1, 8); //genera un numero da 1 a 2 per vedere quale squadra ha l'infortunio

        }


        static void potScuadra(int[] titolari1, int[] titolari2, ref int potenzaS1, ref int potenzaS2)
        {//inizio pot scquadra

            potenzaS1 = 0;
            potenzaS2 = 0;

            for (int i = 0; i < titolari1.Length; i++)
            {

                potenzaS1 = potenzaS1 + titolari1[i];

            }

            for (int i = 0; i < titolari2.Length; i++)
            {

                potenzaS2 = potenzaS2 + titolari2[i];

            }
            Console.WriteLine("potenza scuadra 1: " + potenzaS1);
            Console.WriteLine("potenza scuadra 2: " + potenzaS2);



        }//fine pot scquadra

        static void infortunio(int[] titolari1, int[] titolari2, ref int infortuniS1, ref int infortuniS2)
        {//evento infortunio

            Random rng = new Random();

            int inf = rng.Next(1, 3); //genera un numero da 1 a 2 per vedere quale squadra ha l'infortunio

            if (inf == 1)
            { //infortunio scquadra 1

                Console.WriteLine("Un giocatore della 1 scquadra si e infortunato e ha perso 15 di potenza");

                int giocatoreInf = rng.Next(0, 11); //genera un numero da 0 a 10 per vedere quale giocatore si infortuna

                if (titolari1[giocatoreInf] >= 15)
                {

                    titolari1[giocatoreInf] = titolari1[giocatoreInf] - 15; //diminuisce la potenza del giocatore infortunato

                }
                else
                {// se non maggiore o uguale di 15 la potenza rigira

                    giocatoreInf = rng.Next(0, 11);
                    titolari1[giocatoreInf] = titolari1[giocatoreInf] - 15; //diminuisce la potenza del giocatore infortunato

                }

                infortuniS1 = infortuniS1 + 1;

            }
            else
            {

                Console.WriteLine("Un giocatore della 2 scquadra si e infortunato e ha perso 15 di potenza");

                int giocatoreInf = rng.Next(0, 11); //genera un numero da 0 a 10 per vedere quale giocatore si infortuna

                if (titolari2[giocatoreInf] >= 15)
                {
                    titolari2[giocatoreInf] = titolari2[giocatoreInf] - 15; //diminuisce la potenza del giocatore infortunato
                }
                else
                {// se non maggiore o uguale di 15 la potenza rigira

                    giocatoreInf = rng.Next(0, 11);
                    titolari2[giocatoreInf] = titolari2[giocatoreInf] - 15; //diminuisce la potenza del giocatore infortunato


                }

                infortuniS2 = infortuniS2 + 1;

            }

        }//fine infortunio

        static void caloFisico(int[] titolari1, int[] titolari2)
        { //evento calo fisico

            Random rng = new Random();
            int cF = rng.Next(1, 3); //genera un numero da 1 a 2 per vedere quale squadra ha l'infortunio

            if (cF == 1)
            {//colpisce la prima scquadra

                Console.WriteLine("La stanchezza ha colpito tutta la prima scquadra");

                for (int i = 0; i < titolari1.Length; i++)
                {

                    titolari1[i] = titolari1[i] - 2; //diminuisce la potenza di tutti i giocatori della scquadra 1

                }

            }
            else
            {
                Console.WriteLine("La stanchezza ha colpito tutta la seconda scquadra");
                for (int i = 0; i < titolari2.Length; i++)
                {

                    titolari2[i] = titolari2[i] - 2; //diminuisce la potenza di tutti i giocatori della scquadra 2

                }

            }

        }//fine calo fisico

        static void cartGiallo(int[] titolari1, int[] titolari2, int[] gialli1, int[] gialli2, ref int cartGialli1, ref int cartGialli2)
        { //evento cartellino giallo

            Random rng = new Random();
            int scquadraGiallo = rng.Next(1, 3); //genera un numero da 1 a 2 per vedere quale squadra ha il cartellino giallo

            if (scquadraGiallo == 1)
            { //giallo a scquadra 1

                Console.WriteLine("Un giocatore della prima scquadra ha ricevuto un cartellino giallo");
                int cartGiallo = rng.Next(0, gialli1.Length);
                gialli1[cartGiallo] = gialli1[cartGiallo] + 1; //aggiunge un cartellino giallo al giocatore

                if (gialli1[cartGiallo] == 2)
                {//estensione livello 1(doppio giallo=espulsione

                    Console.WriteLine("Il giocatore numero: " + cartGiallo + " della scquadra n.1 e stato espulso per aver ricevuto 2 cartellini gialli");
                    titolari1[cartGiallo] = 0; //espulsione giocatore
                }
                cartGialli1 = cartGialli1 + 1;
            }
            else
            {

                Console.WriteLine("Un giocatore della seconda scquadra ha ricevuto un cartellino giallo");
                int cartGiallo = rng.Next(0, gialli1.Length);
                gialli2[cartGiallo] = gialli2[cartGiallo] + 1; //aggiunge un cartellino giallo al giocatore

                if (gialli2[cartGiallo] == 2)
                {//estensione livello 1(doppio giallo=espulsione

                    Console.WriteLine("Il giocatore numero: " + cartGiallo + " della scquadra n.2 e stato espulso per aver ricevuto 2 cartellini gialli");
                    titolari2[cartGiallo] = 0; //espulsione giocatore
                }
                cartGialli2 = cartGialli2 + 1;
            }

        }//fine cartellino giallo

        static void cartellinoRosso(int[] titolari1, int[] titolari2, ref int cartRosso1, ref int cartRosso2)
        { //evento cartellino rosso

            Random rng = new Random();
            int scquadraRosso = rng.Next(1, 3); //genera un numero da 1 a 2 per vedere quale squadra ha il cartellino rosso

            if (scquadraRosso == 1)
            { //colpisce scquadra 1

                Console.WriteLine("Un giocatore della prima scquadra ha ricevuto un cartellino rosso");
                int carRosso = rng.Next(0, titolari1.Length); //genera un numero da 0 a 11 per vedere quale giocatore prende il cartellino rosso
                titolari1[carRosso] = 0; //espulsione giocatore

                cartRosso1 = cartRosso1 + 1;

            }
            else
            {//colpisce scquadra 2

                Console.WriteLine("Un giocatore della seconda scquadra ha ricevuto un cartellino rosso");
                int carRosso = rng.Next(0, titolari2.Length); //genera un numero da 0 a 11 per vedere quale giocatore prende il cartellino rosso
                titolari2[carRosso] = 0; //espulsione giocatore

                cartRosso2 = cartRosso2 + 1;
            }

        }//fine cartellino rosso

        // Il problema è che la sostituzione non aggiorna correttamente i valori nei vettori titolari2 e panchina2.
        // Inoltre, la logica di sostituzione per la squadra 2 sta usando panchina1 e titolari1 invece di panchina2 e titolari2.
        // Ecco la correzione della parte relativa alla squadra 2:

        static void sostituzioni(int[] titolari1, int[] titolari2, int[] panchina1, int[] panchina2, ref int contaSost1, ref int contaSost2)
        {
            int maxP = -1000, minT = 1000;

            Random rng = new Random();
            int scquadraSost = rng.Next(1, 3); //genera un numero da 1 a 2 per vedere quale squadra ha la sostituzione

            if (scquadraSost == 1)
            {
                contaSost1 = contaSost1 + 1;

                if (contaSost1 < 5)
                {
                    Console.WriteLine("La scquadra n.1 effettua una sostituzione");

                    int posto1 = 0, posto2 = 0;
                    for (int i = 0; i < titolari1.Length; i++)
                    {
                        if (titolari1[i] < minT)
                        {
                            minT = titolari1[i];
                            posto1 = i;
                        }
                    }

                    for (int j = 0; j < panchina1.Length; j++)
                    {
                        if (panchina1[j] > maxP)
                        {
                            maxP = panchina1[j];
                            posto2 = j;
                        }
                    }

                    // Effettua la sostituzione
                    int temp = titolari1[posto1];
                    titolari1[posto1] = panchina1[posto2];
                    panchina1[posto2] = temp;
                }
                else
                {
                    Console.WriteLine("La scquadra n.1 ha fatto troppe sostituzioni e non puo piu farne");
                    return;
                }
            }
            else
            {
                contaSost2 = contaSost2 + 1;

                if (contaSost2 < 5)
                {
                    int posto1 = 0, posto2 = 0;
                    Console.WriteLine("La scquadra n.2 effettua una sostituzione");

                    for (int i = 0; i < titolari2.Length; i++)
                    {
                        if (titolari2[i] < minT)
                        {
                            minT = titolari2[i];
                            posto1 = i;
                        }
                    }

                    for (int j = 0; j < panchina2.Length; j++)
                    {
                        if (panchina2[j] > maxP)
                        {
                            maxP = panchina2[j];
                            posto2 = j;
                        }
                    }

                    // Effettua la sostituzione
                    int temp = titolari2[posto1];
                    titolari2[posto1] = panchina2[posto2];
                    panchina2[posto2] = temp;
                }
                else
                {
                    Console.WriteLine("La scquadra n.2 ha fatto troppe sostituzioni e non puo piu farne");
                    return;
                }
            }

            Console.WriteLine("Sostituzione fatta: entra: " + maxP + "   esce: " + minT);
        }

        static void RigoriPunizioni(ref int golS1, ref int golS2)
        {

            Random rng = new Random();
            int squadraEv = rng.Next(1, 3); //genera un numero da 1 a 2 per vedere quale squadra ha la sostituzione

            if (squadraEv == 1)
            {//evento in scquadra 1

                int Ev = rng.Next(1, 3); //per vedere se rigore o punizione

                if (Ev == 1)
                { //rigore

                    Console.WriteLine("Alla scquadra 1 viene assegnato un rigore!!");

                    int posRigore = rng.Next(1, 11); //per vedere se fa gol o no

                    if (posRigore <= 5)
                    {//fa gol con rigore

                        Console.WriteLine("Ha segnato il rigore");
                        golS1 = golS1 + 1;

                    }
                    else
                    {//non fa gol con rigore

                        Console.WriteLine("Non ha segnato il rigore");

                    }

                }
                else
                {//evento punizione

                    Console.WriteLine("Alla scquadra 1 viene assegnata una punizione!!");

                    int posRigore = rng.Next(1, 11); //per vedere se fa gol o no

                    if (posRigore <= 3)
                    {//fa gol con punizione

                        Console.WriteLine("Ha segnato la punizione");
                        golS1 = golS1 + 1;
                    }
                    else
                    {//non fa gol di punizione

                        Console.WriteLine("Non ha segnato la punizione");

                    }
                }

            }//fine evento scquadra 1

            else
            {//evento scquadra 2

                int Ev = rng.Next(1, 3); //per vedere se rigore o punizione

                if (Ev == 1)
                { //rigore

                    Console.WriteLine("Alla scquadra 2 viene assegnato un rigore!!");

                    int posRigore = rng.Next(1, 11); //per vedere se fa gol o no

                    if (posRigore <= 5)
                    {//fa gol con rigore

                        Console.WriteLine("Ha segnato il rigore");
                        golS2 = golS2 + 1;

                    }
                    else
                    {//non fa gol con rigore

                        Console.WriteLine("Non ha segnato il rigore");

                    }

                }
                else
                {//evento punizione

                    Console.WriteLine("Alla scquadra 2 viene assegnata una punizione!!");

                    int posRigore = rng.Next(1, 11); //per vedere se fa gol o no

                    if (posRigore <= 3)
                    {//fa gol con punizione

                        Console.WriteLine("Ha segnato la punizione");
                        golS2 = golS2 + 1;
                    }
                    else
                    {//non fa gol di punizione

                        Console.WriteLine("Non ha segnato la punizione");

                    }
                }

            }

        }

        static void Main(string[] args)
        {
            //giocatori titolari
            int[] titolari1 = new int[11];
            int[] titolari2 = new int[11];

            //panchinari
            int[] panchina1 = new int[5];
            int[] panchina2 = new int[5];

            //vettori cartellini Gialli scquadre
            int[] gialli1 = new int[11];
            int[] gialli2 = new int[11];

            //potenza scquadre
            int potenzaS1 = 0, potenzaS2 = 0, infortuniS1 = 0, infortuniS2 = 0, cartGialli1 = 0, cartGialli2 = 0, cartRossi1 = 0, cartRossi2 = 0, contaSost1 = 0, contaSost2 = 0;

            scuadraGen(titolari1, titolari2, panchina1, panchina2); // genera le scuadre e i panchinari

            potScuadra(titolari1, titolari2, ref potenzaS1, ref potenzaS2); // stampa la potenza delle scuadre



            Random rng = new Random();

            int recupero = rng.Next(1, 6); //minuti di recupero generato da 1 a 5

            int tempo = 90 + recupero; //durata partita in minuti

            int golS1 = 0, golS2 = 0; //gol totali delle scuadre

            //inizio del ciclo
            for (int i = 0; i < tempo; i++)
            {

                Console.WriteLine("minuto: " + (i + 1));


                int evento = rng.Next(1, 16); //genera un numero da 1 a 11 per vedere un evento

                if (evento == 1)
                { //evento GOL

                    Gol(ref potenzaS1, ref potenzaS2, ref golS1, ref golS2, titolari1, titolari2);

                    potScuadra(titolari1, titolari2, ref potenzaS1, ref potenzaS2); //ricalcola la potenza delle scquadre dopo il gol

                }

                else if (evento == 2)
                { //evento infortunio

                    infortunio(titolari1, titolari2, ref infortuniS1, ref infortuniS2);

                    potScuadra(titolari1, titolari2, ref potenzaS1, ref potenzaS2); //ricalcola la potenza delle scquadre dopo l'infortunio

                }

                else if (evento == 3)
                { //evento calo fisico

                    caloFisico(titolari1, titolari2);
                    potScuadra(titolari1, titolari2, ref potenzaS1, ref potenzaS2); //ricalcola la potenza delle scquadre dopo l'infortunio

                }

                else if (evento == 4)
                { //evento cartellino giallo

                    cartGiallo(titolari1, titolari2, gialli1, gialli2, ref cartGialli1, ref cartGialli2);
                    potScuadra(titolari1, titolari2, ref potenzaS1, ref potenzaS2); // stampa la potenza delle scuadre

                }

                else if (evento == 5)
                { //cartellino rosso

                    cartellinoRosso(titolari1, titolari2, ref cartRossi1, ref cartRossi2);
                    potScuadra(titolari1, titolari2, ref potenzaS1, ref potenzaS2); // stampa la potenza delle scuadre

                }
                else if (evento == 6)
                {//sostituzioni, estensione lvl 2 ( panchina intelligente )

                    potScuadra(titolari1, titolari2, ref potenzaS1, ref potenzaS2); // stampa la potenza delle scuadre
                    sostituzioni(titolari1, titolari2, panchina1, panchina2, ref contaSost1, ref contaSost2);
                    potScuadra(titolari1, titolari2, ref potenzaS1, ref potenzaS2); // stampa la potenza delle scuadre

                }

                else if (evento == 7)
                {//evento punizione o rigori (estensione lvl3)

                    RigoriPunizioni(ref golS1, ref golS2);

                }

                if (i == 89)
                {

                    Console.WriteLine("La partita e arrivata a 90 minuti, e stato calcolato un recupero di: " + recupero);

                }

            }

            //STATISTICHE FINALI

            //gol delle scquadre
            Console.WriteLine("");
            Console.WriteLine(" ----------------------------------------------------------------------");
            Console.WriteLine("|La prima scquadra ha fatto: " + golS1 + " gol                                     |");
            Console.WriteLine("|La seconda scquadra ha fatto: " + golS2 + " gol                                   |");
            Console.WriteLine(" ----------------------------------------------------------------------");


            //infortuni
            Console.WriteLine("");
            Console.WriteLine(" ----------------------------------------------------------------------");
            Console.WriteLine("|La prima scquadra ha avuto: " + infortuniS1 + " infortuni                               |");
            Console.WriteLine("|La seconda scquadra ha avuto: " + infortuniS2 + " infortuni                             |");
            Console.WriteLine(" ----------------------------------------------------------------------");

            //cartellini gialli
            Console.WriteLine("");
            Console.WriteLine(" -----------------------------------------------------------------------");
            Console.WriteLine("|La prima scquadra ha ricevuto: " + cartGialli1 + " cartellini gialli                     |");
            Console.WriteLine("| seconda scquadra ha ricevuto: " + cartGialli2 + " cartellini gialli                     |");
            Console.WriteLine(" -----------------------------------------------------------------------");

            //cartellini rossi
            Console.WriteLine("");
            Console.WriteLine(" -----------------------------------------------------------------------");
            Console.WriteLine("|La prima scquadra ha ricevuto: " + cartRossi1 + " cartellini rossi                      |");
            Console.WriteLine("|La seconda scquadra ha ricevuto: " + cartRossi2 + " cartellini rossi                    |");
            Console.WriteLine(" -----------------------------------------------------------------------");

            //sostituzioni
            Console.WriteLine("");
            Console.WriteLine(" -----------------------------------------------------------------------");
            Console.WriteLine("|La prima scquadra ha effettuato: " + contaSost1 + " sostituzioni                        |");
            Console.WriteLine("|La seconda scquadra ha effettuato: " + contaSost2 + " sostituzioni                      |");
            Console.WriteLine(" -----------------------------------------------------------------------");
            Console.WriteLine("");

            //Report dettagliato (Estensione lvl 3)
            int sommaCart1 = 0, sommaCart2 = 0;

            sommaCart1 = cartGialli1 + cartRossi1;
            sommaCart2 = cartGialli2 + cartRossi2;

            if (sommaCart1 > sommaCart2)
            {
                Console.WriteLine("La scquadra piu fallosa e stata la scquadra n.1 con un totale di: " + cartGialli1 + " cartellini gialli e: " + cartRossi1 + " cartellini Rossi");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("La scquadra piu fallosa e stata la scquadra n.2 con un totale di: " + cartGialli2 + " cartellini gialli e: " + cartRossi2 + " cartellini Rossi");
                Console.WriteLine("");
            }
        }
    }
}
