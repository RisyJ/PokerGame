using System;
using System.Collections.Generic;

namespace PokerGames
{
    public enum Player
    {
        Player1,
        Player2
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string winner = "", loser = "";
            Console.WriteLine("将15张牌分成三行.\n" +
                    "每行自上而下（其实方向不限）分别是3、5、7张.\n" +
                    "安排两个玩家，每人可以在一轮内，在任意行拿任意张牌，但不能跨行.\n" +
                    "拿最后一张牌的人即为输家.");
           
           //初始化数据
            int[] row1 = { 1, 2, 3 };
            int[] row2 = { 4, 5, 6, 7, 8 };
            int[] row3 = { 9, 10, 11, 12, 13, 14, 15 };
            int[] pokerRowLength = { row1.Length, row2.Length, row3.Length };
            int totalPoker = row1.Length + row2.Length + row3.Length;
            while (totalPoker > 1){
                //玩家1开始拿牌
                int playerTakeNum = TakePoker(Player.Player1, pokerRowLength);
                totalPoker = totalPoker - playerTakeNum;
                if (totalPoker == 1){
                    winner = Player.Player1.ToString();
                    loser = Player.Player2.ToString();
                    break;
                }
                else if(totalPoker == 0){
                    winner = Player.Player2.ToString();
                    loser = Player.Player1.ToString();
                    break;
                }
         
                //玩家2开始拿牌
                playerTakeNum = TakePoker(Player.Player2, pokerRowLength);
                //剩余总牌数
                totalPoker = totalPoker - playerTakeNum;
                if (totalPoker == 1){
                    winner = Player.Player2.ToString();
                    loser = Player.Player1.ToString();
                    break;
                }
                else if (totalPoker == 0){
                    winner = Player.Player1.ToString();
                    loser = Player.Player2.ToString();
                    break;
                }
            }
            Console.WriteLine("赢家"+winner+"，输家"+loser);
            Console.ReadLine();
        }
        public  static int TakePoker(Player player, int[] pokerRowLength)
        {
            Console.WriteLine(" 当前玩家为 " + player.ToString() + ",请输入数字1、2、3表示第几行拿牌");
            for (int i = 0; i < pokerRowLength.Length; i++){
                Console.WriteLine(" 您面前有三行牌，第" + (i + 1).ToString() + "行有 " + pokerRowLength[i] + " 张牌.");
            }
            int playerTakeRow = Convert.ToInt32(Console.ReadLine());
            int playerCanTakeNum = 0;
            if (playerTakeRow < 1 | playerTakeRow > 3){
                Console.WriteLine("请输入1或者2或者3 ");
                //递归
                return TakePoker(player, pokerRowLength);
            }
            if (pokerRowLength[playerTakeRow-1]>0){
                Console.WriteLine(Player.Player1.ToString() + "选择了 " + playerTakeRow + "行，剩余（" + pokerRowLength[playerTakeRow - 1] + "）, 请输入数字获取多少张牌");
                playerCanTakeNum = pokerRowLength[playerTakeRow - 1];
               
            }
            else{
                Console.WriteLine("当前" + playerTakeRow + "行已无牌可选，请重新输入其他行 ");
                //递归
                return TakePoker(player, pokerRowLength);
            }
            int playerTakeNum = Convert.ToInt32(Console.ReadLine());
            if (playerTakeNum < 1 | playerTakeNum > playerCanTakeNum){
                Console.WriteLine("输入错误,请输入1到" + playerCanTakeNum);
                //递归
                return TakePoker(player, pokerRowLength);
            }
            //修改行数剩余数量
            pokerRowLength[playerTakeRow - 1] = pokerRowLength[playerTakeRow - 1] - playerTakeNum;
            Console.WriteLine(Player.Player1.ToString() + "选择了第" + playerTakeRow + "行，拿了（" + playerTakeNum + "）张牌");
            return playerTakeNum;
        }
    }
    
}
