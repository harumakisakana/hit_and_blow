// See https://aka.ms/new-console-template for more information
using System;
using System.Reflection.Metadata;
//ヒットアンドブロー
class Program 
{
    static void Main() 
    {
        const int length = 4;
        int[] ans = new int[length];
        int[] sug = new int[length];
        int[] box = new int[2];
        int[] save = new int[length];
        Random ran = new Random();

        //答えの代入
        for (int i = 0; i < ans.Length; i++)
        {
            ans[i] = ran.Next(0, 9);
            //Console.WriteLine(ans[i]);
            save[i] = ans[i];
            //Console.WriteLine(save[i]);
        }
        
        //答えを入力させる
        Console.WriteLine("{0}ケタの値を入力してください",length);
        do
        {
            int f = int.Parse(Console.ReadLine());
            //Console.WriteLine(f);
            box = suggestion(ans, f);
            Console.WriteLine("{0}ヒット{1}ブローです", box[0], box[1]);
            for (int i = 0; i < ans.Length; i++) { ans[i] = save[i]; }
            //Console.WriteLine("{0},{1},{2},{3}", ans[0], ans[1], ans[2], ans[3]);
            //Console.WriteLine("{0},{1},{2},{3}", save[0], save[1], save[2], save[3]);
        }
        while (box[0] != length);
        Console.WriteLine("答えは{0}{1}{2}{3}でした", ans[3], ans[2], ans[1], ans[0]);
    }

    static int[] suggestion(int[] answer, int suggest) 
    {
        int[] sugs = new int[answer.Length];
        int[] box = new int[2];
        int hit = 0;
        int blow = 0;
        //Console.WriteLine(sug);
        //0:一の位,1:十の位,2:百の位,3:千の位
        for (int i = 0; i < answer.Length; i++)
        {
            sugs[i] = suggest % 10;
            suggest = suggest / 10;
            //Console.WriteLine(sugs[i]);
        }

        //ヒットの処理
        for (int i = 0; i < answer.Length; i++)
        {
            if (answer[i] == sugs[i])
            {
                hit += 1;
                answer[i] = 10;
                sugs[i] = 11;
            }
        }

        //ブローの処理
        for (int i = 0; i < answer.Length; i++)
        {
            for (int j = 0; j < sugs.Length; j++)
            {
                if (answer[i] == sugs[j])
                {
                    blow += 1;
                    answer[i] = 12;
                    sugs[j] = 13;
                    break;
                }
            }
        }

        box[0] = hit;
        box[1] = blow;
        return box;
    }
}
