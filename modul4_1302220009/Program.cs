public class Program
{
    public enum NamaBuah
    {
        Apel, Aprikot, Alpukat,
        Pisang, Paprika, Blackberry,
        Ceri, Kelapa, Jagung
    }

    public class KodeBuah
    {
        public NamaBuah namaBuah;
        public KodeBuah(NamaBuah namaBuah)
        {
            this.namaBuah = namaBuah;
        }
        String[] nomorKodeBuah =
        {
            "A00", "B00", "C00",
            "D00", "E00", "F00",
            "H00", "I00",
            "J00", "K00", "L00",
            "M00", "N00", "O00"
        };
        public String getKodeBuah()
        {
            return nomorKodeBuah[(int)namaBuah];
        }
    }
    public enum KarakterState
    {
        Berdiri, Tengkurap,
        Terbang, Jongkok
    }

    public enum Trigger
    {
        TombolS, TombolW, TombolX
    }

    public class PosisiKarakterGame
    {
        public class Transition
        {
            public KarakterState firstState;
            public KarakterState lastState;
            public Trigger trigger;

            public Transition(KarakterState firstState, KarakterState lastState, Trigger trigger)
            {
                this.firstState = firstState;
                this.lastState = lastState;
                this.trigger = trigger;
            }
        }

        Transition[] transisi =
        {
            new Transition(KarakterState.Tengkurap, KarakterState.Jongkok, Trigger.TombolW),
            new Transition(KarakterState.Jongkok, KarakterState.Tengkurap, Trigger.TombolS),
            new Transition(KarakterState.Jongkok, KarakterState.Berdiri, Trigger.TombolW),
            new Transition(KarakterState.Berdiri, KarakterState.Jongkok, Trigger.TombolS),
            new Transition(KarakterState.Berdiri, KarakterState.Terbang, Trigger.TombolW),
            new Transition(KarakterState.Terbang, KarakterState.Berdiri, Trigger.TombolS),
            new Transition(KarakterState.Terbang, KarakterState.Jongkok, Trigger.TombolX)
        };

        public KarakterState currentState = KarakterState.Berdiri;

        public KarakterState getNextState(KarakterState firstState, Trigger trigger)
        {
            KarakterState lastState = firstState;

            for (int i = 0; i < transisi.Length; i++)
            {
                Transition perubahan = transisi[i];
                if (transisi[i].firstState == firstState && transisi[i].trigger == trigger)
                {
                    lastState = transisi[i].lastState;
                }
            }
            return lastState;
        }

        public void activeTrigger(Trigger trigger)
        {
            KarakterState lastState = getNextState(currentState, trigger);
            currentState = lastState;

            if (currentState == KarakterState.Berdiri)
            {
                Console.WriteLine("Posisi Standby");
            } else if (currentState == KarakterState.Tengkurap)
            {
                Console.WriteLine("Posisi Istirahat");
            }
            Console.WriteLine("Posisi anda sedang " + currentState + " karena anda " + trigger);
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            KodeBuah b1 = new KodeBuah(NamaBuah.Pisang);
            Console.WriteLine("Buah " + b1.namaBuah + " memiliki kode: " + b1.getKodeBuah());
            Console.WriteLine();

            PosisiKarakterGame k1 = new PosisiKarakterGame();
            Console.WriteLine("Posisi anda sedang " + k1.currentState);
            Console.WriteLine();

            k1.activeTrigger(Trigger.TombolS);
            k1.activeTrigger(Trigger.TombolS);
            k1.activeTrigger(Trigger.TombolW);
            k1.activeTrigger(Trigger.TombolW);
            k1.activeTrigger(Trigger.TombolW);
            k1.activeTrigger(Trigger.TombolS);
            k1.activeTrigger(Trigger.TombolW);
            k1.activeTrigger(Trigger.TombolX);
        }
    }
}