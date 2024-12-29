// See https://aka.ms/new-console-template for more information


using System.Text;

static List<List<string>> Soultion()
{
    var queen = new QueenN(8);
    queen.SetQ(0); // 從第0行 第0列開始排
    return queen.answerList;
}


var solution=Soultion();

int count = 1;
foreach (var answer  in solution)
{
    Console.WriteLine($"----Solution {count}----");
    foreach (var row in answer)
    {       
        Console.WriteLine(row);
    }
    count++;
}


/*
    n*n 棋盤
    擺 n 個皇后

    彼此不能互相攻擊到 ( 橫行、 值列 、 斜線 都不相交)

    求所有的擺法?
    以一個一維陣列 代表其中一個擺法

    index 行數， 該行 放置Q 的列 標示為Q，其他為.  [..Q..]

    再用一個list 包住所有的擺法 List<List<string>>


    思路
    1. 以一個array[n] 裝其中一個排法

        index 代表行數， array[n] 代表列數

    2. 從第 0 行 第 0 列開排，一行一行排，排完 n 行代表找到其中一個解

    3. 每次排都要判斷不能與之前 n 個排過的 Q 相交

    如何判斷不相交 ?

    1. 橫行 :  迴圈一行一行排，所以不用判斷
    2. 直列 :  for  array[i] == array[n] 代表前幾列的某個Q 跟 當前排的重複列了
    3. 斜線 :  Q之間 行、列差距 相同 代表同一個斜率， 負斜率也算相交，所以取絕對值 
               Math.Abs(i-n) == Math.Abs(array[i] - array[n] )   

    遞歸運作模式
    從第0行第0列開始排，以此為基礎找出接下來其他行所有排法，接著 是 第0行第1列， 以此為基礎找出接下來其他行所有排法





*/



public class QueenN
{
    int max;
    int[] array; // 使用一個一維陣列 表示棋盤上Q的位置

    public List<List<string>> answerList = new List<List<string>>();

    public QueenN(int n )
    {
        max = n;
        array = new int[n];
    }

    public void SetQ(int n)
    {
        if(n == max)
        {
            RecordSolution();
            return;
        }

        for (int i = 0; i < max; i++) 
        {
            array[n] = i;
            if (IsNoConflict(n))
            {
                SetQ(n + 1);
            }
        }


    }

    private bool IsNoConflict(int n)
    {
        for (int i = 0; i<n; i++) 
        {
            // 直列 與 斜線 不相交
            if (array[i] == array[n] || Math.Abs(i-n) == Math.Abs(array[i] - array[n]))
            {
                return false;
            }
        }

        return true;
    }

    private void RecordSolution()
    {
        var answer = new List<string>();
        for (int i = 0; i < array.Length; i++)
        {

            var row = new StringBuilder(new string('.',array.Length));
            row[array[i]] = 'Q';
            answer.Add(row.ToString());    
        }
        answerList.Add(answer);
    }
}


