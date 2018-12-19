/*
 * Copyright (c) 2017 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using UnityEngine;
using System.Collections;
using TMPro;

public class GlobalStateManager : MonoBehaviour
{
    private int deadPlayer = 0;
    private int deadPlayerNumber = -1;

    public GameObject playerWin;

    public void PlayerDied (int playerNumber)
    {
        deadPlayer++;

        if(deadPlayer == 1)
        {
            deadPlayerNumber = playerNumber;
            Invoke("CheckPlayerDeath", 1.0f);
        }
    }

    void Start()
    {
        playerWin.SetActive(false);
    }

    void CheckPlayerDeath()
    {
        playerWin.SetActive(true);
        if (deadPlayer == 1)
        {
            if(deadPlayerNumber == 1)
            {
                playerWin.GetComponent<TextMeshPro>().text = "Player 2 Win";
            }
            else if(deadPlayerNumber == 2)
            {
                playerWin.GetComponent<TextMeshPro>().text = "Player 1 Win";
            }
        }
        else
        {
            playerWin.GetComponent<TextMeshPro>().text = "In A Draw";
        }
    }
}
