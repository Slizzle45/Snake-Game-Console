using System;

namespace Konsol_Yılan_Oyunu
{
    class Yılan
    {
        public static void Yazdır(int x, int y, string yazı) // Verilen konuma yazdırma
        {
            Console.SetCursorPosition(x, y);
            Console.Write(yazı);
        }

        public static void Main(string[] args)
        {
            string boş = " ";
            bool playerAlive = true; /* Oyunun sadece oyuncu hayattayken oynanabilmesi,
                                        aksi takdirde tuşların çalışmaması için bir bool oluşturdum */
            char ch;
            string kafa = "0";
            string kuyruk = "*";
            Console.CursorVisible = false;
            // Kafa "0" konum değerleri
            int x = 42;
            int y = 15;
            // Kuyruk "*" konum değerleri 4 elemanlı bir dizi.
            int[] konumX = { 41, 40, 39, 38 };
            int[] konumY = { 15, 15, 15, 15 };
            // Kafayı yazdır
            Yılan.Yazdır(x, y, kafa);
            // Kuyruğu yazdır
            for (int i = 0; i < 4; i++)
            {
                Yılan.Yazdır(konumX[i], konumY[i], kuyruk);
            }

            // Hareket
            while (true)
            {
                if (playerAlive == true) // Hareket fonksiyonu kullanıcı hayattaysa çalışacak
                {

                    ch = Console.ReadKey(true).KeyChar; // Kullanıcıdan tuş okuma
                    switch (ch)
                    {
                        // wasd girilen tuşa göre case'ler
                        case 'w':
                            // Yılanın tek kare yer değiştirmesi için kuyruğunun en uç noktasını sil
                            Yılan.Yazdır(konumX[3], konumY[3], boş);
                            // Kuyruğun en ucundan (3) başlayarak bir ilerki nokta ile konumlarını değiştir.
                            for (int i = 3; i > 0; i--)
                            {
                                konumX[i] = konumX[i-1];
                                konumY[i] = konumY[i-1];

                            }
                            // Kuyruğun başa en yakın kısmının konumunu baş'ın yer değiştirmeden önceki yerine eşitle
                            konumX[0] = x;
                            konumY[0] = y;
                            // Baş'ın yerini değiştirmeden önce başın olduğu yere kuyruk yazdır
                            Yılan.Yazdır(konumX[0], konumY[0], kuyruk);
                            ////////// Kontroller ////////////////
                            //Ekran dışına çıktı mı
                            if (y == 0)
                            {
                                // Çıktıysa oyun bitiyor.
                                playerAlive = false;
                                Yılan.IsGameOver(playerAlive);
                            }
                            else
                                y--; // Baş'ın hareketi
                            // Kendine çarptı mı?
                            for (int i = 0; i < 4; i++)
                            {
                                if (x == konumX[i] && y == konumY[i])
                                {
                                    playerAlive = false;
                                    Yılan.IsGameOver(playerAlive);
                                }
                            }
                            // Baş'ı yazdır
                            Yılan.Yazdır(x, y, kafa);

                            break;
                        //
                        case 'a':
                            Yılan.Yazdır(konumX[3], konumY[3], boş);
                            for (int i = 3; i > 0; i--)
                            {
                                konumX[i] = konumX[i-1];
                                konumY[i] = konumY[i-1];
                            }
                            konumX[0] = x;
                            konumY[0] = y;

                            Yılan.Yazdır(konumX[0], konumY[0], kuyruk);
                            if (x == 0)
                            {
                                playerAlive = false;
                                Yılan.IsGameOver(playerAlive);
                            }
                            else
                                x--;
                            for (int i = 0; i < 4; i++)
                            {
                                if (x == konumX[i] && y == konumY[i])
                                {
                                    playerAlive = false;
                                    Yılan.IsGameOver(playerAlive);
                                }
                            }
                            Yılan.Yazdır(x, y, kafa);
                            break;
                        //
                        case 's':
                            Yılan.Yazdır(konumX[3], konumY[3], boş);
                            for (int i = 3; i > 0; i--)
                            {
                                konumX[i] = konumX[i-1];
                                konumY[i] = konumY[i-1];
                            }
                            konumX[0] = x;
                            konumY[0] = y;

                            Yılan.Yazdır(konumX[0], konumY[0], kuyruk);
                            if (y == Console.WindowHeight-1)
                            {
                                playerAlive = false;
                                Yılan.IsGameOver(playerAlive);
                            }
                            else
                                y++;
                            for (int i = 0; i < 4; i++)
                            {
                                if (x == konumX[i] && y == konumY[i])
                                {
                                    playerAlive = false;
                                    Yılan.IsGameOver(playerAlive);
                                }
                            }
                            Yılan.Yazdır(x, y, kafa);
                            break;
                        //
                        case 'd':
                            Yılan.Yazdır(konumX[3], konumY[3], boş);
                            for (int i = 3; i > 0; i--)
                            {
                                konumX[i] = konumX[i-1];
                                konumY[i] = konumY[i-1];
                            }
                            konumX[0] = x;
                            konumY[0] = y;

                            Yılan.Yazdır(konumX[0], konumY[0], kuyruk);
                            if (x == Console.WindowWidth-1)
                            {
                                playerAlive = false;
                                Yılan.IsGameOver(playerAlive);
                            }
                            else
                                x++;
                            for (int i = 0; i < 4; i++)
                            {
                                if (x == konumX[i] && y == konumY[i])
                                {
                                    playerAlive = false;
                                    Yılan.IsGameOver(playerAlive);
                                }
                            }
                            Yılan.Yazdır(x, y, kafa);
                            break;
                    }
                }
            }



            Console.ReadKey(true);
        }



        // Oyun bitti mi? playerAlive = False gelirse Game Over ekranı görünecek
        public static void IsGameOver(bool alive)
        {
            if (alive == false)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                for (int i = 0; i < 20; i++)
                {
                    Console.Write("GAME OVER   ");
                    Console.Write("GAME OVER   ");
                    Console.Write("GAME OVER   ");
                    Console.Write("GAME OVER   ");
                    Console.Write("GAME OVER   ");
                    Console.Write("GAME OVER   ");
                    Console.Write("GAME OVER   ");
                    Console.Write("GAME OVER   ");
                    Console.Write("GAME OVER   ");
                    Console.Write("GAME OVER   ");
                    Console.Write("GAME OVER   ");
                    Console.Write("GAME OVER   ");
                    Console.Write("GAME OVER   ");
                    Console.Write("GAME OVER   ");
                    Console.Write("GAME OVER   ");
                    Console.Write("GAME OVER   ");
                    Console.Write("GAME OVER   ");
                    Console.Write("GAME OVER   ");
                    Console.Write("GAME OVER   ");
                    Console.Write("GAME OVER   ");
                }
            }
        }
    }
}
