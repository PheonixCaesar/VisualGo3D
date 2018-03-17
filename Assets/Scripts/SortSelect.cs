using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SortSelect : MonoBehaviour {

    public GameObject BubButton, SelButton, InsButton, MerButton, QuiButton, RQButton, CouButton, RadButton;

    public void OnBubClicked() {
        Sort.mode = 1;
        SceneManager.LoadScene("Sort");
    }
    public void OnSelClicked() {
        Sort.mode = 2;
        SceneManager.LoadScene("Sort");
    }
    public void OnInsClicked() {
        Sort.mode = 3;
        SceneManager.LoadScene("Sort");
    }
    public void OnMerClicked() {
        Sort.mode = 4;
        SceneManager.LoadScene("Sort");
    }
    public void OnQuiClicked() {
        Sort.mode = 5;
        SceneManager.LoadScene("Sort");
    }
    //public void OnRQClicked() {
    //    Sort.mode = 6;
    //    SceneManager.LoadScene("Sort");
    //}
    //public void OnCouClicked() {
    //    Sort.mode = 7;
    //    SceneManager.LoadScene("Sort");
    //}
    //public void OnRadClicked() {
    //    Sort.mode = 8;
    //    SceneManager.LoadScene("Sort");
    //}
}
