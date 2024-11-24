using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //does this need to be the specific name of the hand animation controller?
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("A"))
        {
            IsSteeringLeft
            IsSteeringRight
            Is
            
            // is there a way to reference when the existing code for when the player turns left? and then we use that to set the bool to true?
            // Is that a smart way to do it?


            // This code that's written right now is the best I can do. I don't know how to execute referencing the other sections that would have player interactions.
            
            //if we can't figure this out, would it be easier to export specific arm poses as fbxs without animation data.
            //Then create code that references the functions that already exist, like pressing A to steer.
            //Every time that happens we would turn these fbxs' visibility on and off for every player interaction.

            animator.SetBool("IsSteeringRight", true);
        }
        else
        // if (!Input.GetKey("A"))
        {

            animator.SetBool("IsSteeringRight", false);
        
        }
    
    }
}
