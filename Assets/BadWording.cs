using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine;
using KModkit;

public class BadWording : MonoBehaviour
{
    public KMAudio bombaudio;
    public KMBombInfo bomb;
    public KMBombModule module;
    public KMSelectable[] buttons;
    public TextMesh[] texts;
    public Material[] materials;
    public KMColorblindMode colorblind;
    public AudioSource soundsource;
    public AudioClip soundclip;
    

    private List<SentenceObject> sentencepieces = 
        new List<SentenceObject>(){ new SentenceObject { name = "THIS", value = 3, set = new List<int>(){1 } },
                                    new SentenceObject{ name = "YOUR", value = 8, set = new List<int>(){1 }},
                                    new SentenceObject{ name = "OUR", value = 2, set = new List<int>(){1 }},
                                    new SentenceObject{ name = "HIS", value = 5, set = new List<int>(){1 }},
                                    new SentenceObject{ name = "HER", value = 6, set = new List<int>(){1 }},
                                    new SentenceObject{ name = "MY", value = 4, set = new List<int>(){1 }},
                                    new SentenceObject{ name = "THAT", value = 7, set = new List<int>(){1 }},
                                    new SentenceObject{ name = "YOUR", value = 1, set = new List<int>(){1 }},
                                    new SentenceObject{ name = "HIM'S", value = 9, set = new List<int>(){1 }},
                                    new SentenceObject{ name = "HER'S", value = 9, set = new List<int>(){1 }},
                                    new SentenceObject{ name = "MODULE", value = 7, set = new List<int>(){2 } },
                                    new SentenceObject{ name = "BOMB", value = 2, set = new List<int>(){2 } },
                                    new SentenceObject{ name = "SENTENCE", value = 4, set = new List<int>(){2 } },
                                    new SentenceObject{ name = "WORD", value = 3, set = new List<int>(){2 } },
                                    new SentenceObject{ name = "PHRASE", value = 9, set = new List<int>(){2 } },
                                    new SentenceObject{ name = "MANUAL", value = 3, set = new List<int>(){2 } },
                                    new SentenceObject{ name = "WIRE", value = 5, set = new List<int>(){2 } },
                                    new SentenceObject{ name = "BUTTON", value = 5, set = new List<int>(){2 } },
                                    new SentenceObject{ name = "THING", value = 8, set = new List<int>(){2 } },
                                    new SentenceObject{ name = "NUMBER", value = 1, set = new List<int>(){2 } },
                                    new SentenceObject{ name = "IS", value = 5, set = new List<int>(){3,7,8 } },
                                    new SentenceObject{ name = "AM", value = 3, set = new List<int>(){3,7,8 } },
                                    new SentenceObject{ name = "ARE", value = 9, set = new List<int>(){3,7,8 } },
                                    new SentenceObject{ name = "WILL", value = 8, set = new List<int>(){3,7,8 } },
                                    new SentenceObject{ name = "BE", value = 3, set = new List<int>(){3,7,8 } },
                                    new SentenceObject{ name = "AMN'T", value = 1, set = new List<int>(){3,7,8 } },
                                    new SentenceObject{ name = "WON'T", value = 6, set = new List<int>(){3,7,8 } },
                                    new SentenceObject{ name = "WERE", value = 4, set = new List<int>(){3,7,8 } },
                                    new SentenceObject{ name = "BEEN", value = 7, set = new List<int>(){3,7,8 } },
                                    new SentenceObject{ name = "DO", value = 2, set = new List<int>(){3,7,8 } },
                                    new SentenceObject{ name = "YES", value = 6, set = new List<int>(){4,10} },
                                    new SentenceObject{ name = "NO", value = 4, set = new List<int>(){4,10} },
                                    new SentenceObject{ name = "OKAY", value = 2, set = new List<int>(){4,10} },
                                    new SentenceObject{ name = "OK", value = 5, set = new List<int>(){4,10} },
                                    new SentenceObject{ name = "UHHH", value = 7, set = new List<int>(){4,10} },
                                    new SentenceObject{ name = "DONE", value = 8, set = new List<int>(){4,10} },
                                    new SentenceObject{ name = "OH", value = 4, set = new List<int>(){4,10} },
                                    new SentenceObject{ name = "ON", value = 9, set = new List<int>(){4,10} },
                                    new SentenceObject{ name = "OFF", value = 1, set = new List<int>(){4,10} },
                                    new SentenceObject{ name = "HABERDASHERY", value = 3, set = new List<int>(){4,10} },
                                    new SentenceObject{ name = "BECAUSE", value = 4, set = new List<int>(){5} },
                                    new SentenceObject{ name = "HOWEVER", value = 9, set = new List<int>(){5} },
                                    new SentenceObject{ name = "AS", value = 8, set = new List<int>(){5} },
                                    new SentenceObject{ name = "WHILE", value = 7, set = new List<int>(){5} },
                                    new SentenceObject{ name = "HOW", value = 6, set = new List<int>(){5} },
                                    new SentenceObject{ name = "SINCE", value = 1, set = new List<int>(){5} },
                                    new SentenceObject{ name = "THOUGH", value = 2, set = new List<int>(){5} },
                                    new SentenceObject{ name = "BUT", value = 8, set = new List<int>(){5} },
                                    new SentenceObject{ name = "NOR", value = 3, set = new List<int>(){5} },
                                    new SentenceObject{ name = "AND", value = 5, set = new List<int>(){5} },
                                    new SentenceObject{ name = "DEFUSE", value = 1, set = new List<int>(){6} },
                                    new SentenceObject{ name = "SOLVE", value = 4, set = new List<int>(){6} },
                                    new SentenceObject{ name = "CUT", value = 2, set = new List<int>(){6} },
                                    new SentenceObject{ name = "PRESS", value = 9, set = new List<int>(){6} },
                                    new SentenceObject{ name = "DETONATE", value = 6, set = new List<int>(){6} },
                                    new SentenceObject{ name = "DIE", value = 1, set = new List<int>(){6} },
                                    new SentenceObject{ name = "STOP", value = 3, set = new List<int>(){6} },
                                    new SentenceObject{ name = "THROW", value = 8, set = new List<int>(){6} },
                                    new SentenceObject{ name = "SMASH", value = 7, set = new List<int>(){6} },
                                    new SentenceObject{ name = "YEET", value = 5, set = new List<int>(){6} },
                                    new SentenceObject{ name = "HAPPEN", value = 4, set = new List<int>(){9} },
                                    new SentenceObject{ name = "OCCUR", value = 3, set = new List<int>(){9} },
                                    new SentenceObject{ name = "FORGET", value = 6, set = new List<int>(){9} },
                                    new SentenceObject{ name = "DESTROY", value = 5, set = new List<int>(){9} },
                                    new SentenceObject{ name = "SUCCEED", value = 9, set = new List<int>(){9} },
                                    new SentenceObject{ name = "COMPLETE", value = 8, set = new List<int>(){9} },
                                    new SentenceObject{ name = "FINISH", value = 5, set = new List<int>(){9} },
                                    new SentenceObject{ name = "LOGIC", value = 7, set = new List<int>(){9} },
                                    new SentenceObject{ name = "TURN", value = 1, set = new List<int>(){9} },
                                    new SentenceObject{ name = "ABOUT", value = 2, set = new List<int>(){9} }
    };

    private List<SentenceObject> chosenlist = new List<SentenceObject>();

    private List<ColorObject> colors = new List<ColorObject>(10); 

    class SentenceObject
    {
        public int value { get; set; }
        public string name { get; set; }
        public List<int> set { get; set; }
        public ColorObject color { get; set; }
    }

    class ColorObject
    {
        public int value { get; set; }
        public Material color { get; set; }
        public string name { get; set; }
    }

    private int solution = 0;

    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;
    private bool moduleReady = false;

    private void Awake()
    {
        moduleId = moduleIdCounter++;
        foreach (KMSelectable button in buttons)
        {
            KMSelectable pressedButton = button;
            button.OnInteract += delegate () { ButtonPress(pressedButton); return false; };
        }
    }


    // Use this for initialization
    void Start()
    {
        colors = new List<ColorObject>() {
            new ColorObject { color = materials[0], value = 9, name = "Red" },
            new ColorObject { color = materials[1], value = 2, name = "Orange" },
            new ColorObject { color = materials[2], value = 1, name = "Yellow" },
            new ColorObject { color = materials[3], value = 4, name = "Purple" },
            new ColorObject { color = materials[4], value = 6, name = "Blue" },
            new ColorObject { color = materials[5], value = 10, name = "Magenta" },
            new ColorObject { color = materials[6], value = 7, name = "Green" },
            new ColorObject { color = materials[7], value = 8, name = "Cyan" },
            new ColorObject { color = materials[8], value = 3, name = "Black" },
            new ColorObject { color = materials[9], value = 5, name = "White" }
        };
        GetChosenList();
        solution = GenerateSolution();
        Log("The digital root is: " + solution);
        Log("Press the button that says: " + chosenlist[solution-1].name);
        moduleReady = true;
    }

    void GetChosenList()
    {
        var sentence = "";
        var colorlist = "";
        var valueslist = "";
        var colorvalueslist = "";
        var colorselector = 0;
        var colorblindlist = "";
        for(var i = 0; i < 10; i++)
        {
            colorselector = UnityEngine.Random.Range(0, 10);
            chosenlist.Add(new SentenceObject());
            sentencepieces.Select(c => c.value).ToList();
            chosenlist[i] = sentencepieces.FindAll(c => c.set.Contains(i+1)).ElementAt(UnityEngine.Random.Range(0, 10));
            chosenlist[i].color = colors[colorselector];
            sentence += chosenlist[i].name + " ";
            texts[i].text = chosenlist[i].name;
            if (texts[i].text.Length > 3) texts[i].transform.localScale = new Vector3((4f/((float)texts[i].text.Length+2)) * texts[i].transform.localScale.x, texts[i].transform.localScale.y);
            texts[i].color = materials[colorselector].color;
            if (i < 9)
            {
                colorlist += chosenlist[i].color.name + ", ";
                valueslist += chosenlist[i].value + ", ";
                colorvalueslist += chosenlist[i].color.value + ", ";
            }
            else
            {
                colorlist += chosenlist[i].color.name;
                valueslist += chosenlist[i].value;
                colorvalueslist += chosenlist[i].color.value;
            }
            if (chosenlist[i].color.name != "Black") colorblindlist += chosenlist[i].color.name[0];
            else colorblindlist += "K";
        }
        Log("The sentence is: " + sentence);
        Log("The sentence has values: " + valueslist);
        Log("The colors are: " + colorlist);
        Log("The colors have values: " + colorvalueslist);

        if (colorblind.ColorblindModeActive) texts[10].text = colorblindlist;
        else texts[10].text = "";
    }

    int GenerateSolution()
    {
        var solution = 0;
        for(var i = 0; i < 10; i++)
        {
            solution += chosenlist[i].value * chosenlist[i].color.value;
        }
        Log("The sum is: " + solution);
        return DigitalRoot(solution);
    }

    int DigitalRoot(int num)
    {
        var sum = 0;
        while(num != 0)
        {
            sum += num % 10;
            num /= 10;
        }
        if (sum > 9) return DigitalRoot(sum);
        else return sum;
    }

    void ButtonPress(KMSelectable button)
    {
        if (moduleReady)
        {
            bombaudio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, this.transform);           
            button.AddInteractionPunch();
            if (button.name[button.name.Length - 1] == '0')
            {
                Log("Defuser pressed button 10... but... 10 is never possible with Digital Root... Strike...");
                module.HandleStrike();
                StartCoroutine(PlaySound());               
            }
            else if (button.name[button.name.Length - 1] == solution.ToString()[0]) {
                Log("Defuser correctly pressed " + chosenlist[solution - 1].name + "! Module Solved!");
                module.HandlePass();
                moduleReady = false;
                bombaudio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.CorrectChime, this.transform);
            }
            else
            {
                Log("Defuser incorrectly pressed " + chosenlist[-1 + (int)char.GetNumericValue(button.name[button.name.Length - 1])].name + "! Strike!");
                module.HandleStrike();
            }
        }
    }

    IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(1f);
        soundsource.clip = soundclip;
        soundsource.Play();
        yield return new WaitForSeconds(3f);
    }

    private void Log(string s)
    {
        Debug.LogFormat("[Bad Wording #{0}] " + s, moduleId);
    }

}    