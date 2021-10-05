using UnityEngine;
using UnityEngine.UI;

public class DmgAnim : MonoBehaviour
{
    public Animator anim;
    public Text dmgText;
    void Start()
    {
        anim.SetTrigger("triggerAnim");
        dmgText.text = "" + DataHolder.instance.dmg;
    }
    private void Update()
    {
        this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 2);
    }
    public void AnimEnd()
    {
        Destroy(this.gameObject);
    }
}
