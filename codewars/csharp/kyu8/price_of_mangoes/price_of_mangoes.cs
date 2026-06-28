using System;

namespace Codewars.Solutions.Kyu8.price_of_mangoes;

public class PriceOfMangoes
{
    public static int Solution(int quantity, int price)
    {
        double freeMangoes = Math.Floor((double)quantity / 3);

        return (quantity - (int)freeMangoes) * price;
    }
}
