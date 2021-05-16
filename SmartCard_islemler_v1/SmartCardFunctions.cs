using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SmartCard_islemler_v1
{
    public class SmartCard
    {
        CardNative iCard;
        public string reader;
        public bool connected;

        public SmartCard(string ReaderName)
        {
            //MessageBox.Show("SmartCard(string ReaderName)   NOKTASI", "ÖZEL MESAJ 1");
            Debug.Print("SmartCard(string ReaderName)   NOKTASI", "ÖZEL MESAJ 1");
            connected = false;
            reader = "";
            iCard = new CardNative();
            findReader(ReaderName);
            reader = ReaderName;
        }

        public int findReader(string ReaderName)
        {
            //MessageBox.Show("1. NOKTA");
            Debug.Print("1. NOKTA ");
            string driverlar = "";
            string[] readers = iCard.ListReaders();

            //  test kuveyt 
            for (int index = 0; index < readers.Length; index++)
            {
                driverlar += readers[index].ToString() + "\n";
            }

            //MessageBox.Show("2. NOKTA");
            Debug.Print("2. NOKTA ");
            //MessageBox.Show(driverlar , "BULUNAN READERLAR");

            #region   LOGLAMA

            //try
            //{

            //string ErrorFile = @"c:\bberror\TEST_LOG_" + DateTime.Now.Date.ToLongDateString().Replace("/", "") + ".txt";
            //if (!Directory.Exists(@"c:\bberror"))
            //{
            //    Directory.CreateDirectory(@"c:\bberror");
            //}
            //if (!File.Exists(ErrorFile))
            //{
            //    FileStream fs = null;
            //    fs = File.Create(ErrorFile);
            //    fs.Close();
            //}



            //using (StreamWriter sw1 = new StreamWriter(ErrorFile, true))
            //{
            //    MessageBox.Show("3. NOKTA");
            //    Debug.Print("3. NOKTA ");
            //    sw1.WriteLine("Meriç Reports:");
            //    sw1.WriteLine("-------------------------------------------");
            //    sw1.WriteLine("FOUND READERLIST:");
            //    Debug.WriteLine("FOUND READERLIST:");
            //    for (int index = 0; index < readers.Length; index++)
            //    {
            //        sw1.WriteLine(readers[index].ToString());
            //        Debug.WriteLine(readers[index].ToString());

            //    }
            //    sw1.WriteLine("-------------------------------------------");
            //    sw1.WriteLine("");
            //    sw1.Close();
            //}
            // }

            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message,"ÖZEL MESAJ 2 !");
            //    MessageBox.Show(ex.StackTrace, "ÖZEL MESAJ 2 !");
            //}
            #endregion



            for (int index = 0; index < readers.Length; index++)
            {
                if (readers[index] == ReaderName)
                {
                    return index;
                }
            }



            throw new Exception("'" + ReaderName + "'" + " isminde bir akıllı kart okuyucu mevcut değil");
        }

        public bool connect()
        {
            try
            {
                iCard.Connect(reader, SHARE.Shared, PROTOCOL.T0orT1);
                Trace.WriteLine(String.Format("PCSC: Connected to the card on '{0}'", reader));
                connected = true;
            }
            catch (Exception e)
            {
                connected = false;
                Trace.WriteLine(String.Format("PCSC: The smart card reader is returned with an error while connecting! '{0}'", e.Message));
                throw new Exception(reader + " akıllı kart okuyucusuna bağlanılamadı");
            }
            return connected;
        }

        public APDUResponse transmit(APDUCommand apduCommand)
        {
            APDUResponse apduResponse;
            try
            {
                apduResponse = iCard.Transmit(apduCommand);
                Trace.WriteLine(String.Format("PCSC: Transmitted to the card on '{0}'", reader));
            }
            catch (Exception ex)
            {
                Trace.WriteLine(String.Format("PCSC: The smart card reader is returned with an error while transmitting! '{0}'", ex.Message));
                return null;
            }
            return apduResponse;
        }
        public bool disconnect()
        {
            try
            {
                iCard.Disconnect(DISCONNECT.Unpower);
                Trace.WriteLine(String.Format("PCSC: Disconnected from the card on '{0}'", reader));
            }
            catch (Exception ex)
            {
                Trace.WriteLine(String.Format("PCSC: The smart card reader is returned with an error while disconnecting! '{0}'", ex.Message));
                return false;
            }
            connected = false;
            return true;
        }

        public bool WarmReset(ref byte[] ATR)
        {
            try
            {
                uint atrLen = 0;
                if (!iCard.CardReConnect((int)DISCONNECT.Reset))
                    return false;

                if (!iCard.CardStatus(reader, ref ATR, ref atrLen))
                    return false;
                if (!iCard.CardStatus(reader, ref ATR, ref atrLen))
                    return false;

                Array.Resize(ref ATR, (int)atrLen);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ColdReset(ref byte[] ATR)
        {
            try
            {
                uint atrLen = 0;
                if (!iCard.CardReConnect((int)DISCONNECT.Unpower))
                    return false;
                if (!iCard.CardStatus(reader, ref ATR, ref atrLen))
                    return false;
                if (!iCard.CardStatus(reader, ref ATR, ref atrLen))
                    return false;
                Array.Resize(ref ATR, (int)atrLen);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}


