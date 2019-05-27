# ShowBot

The official artificial intelligence bot for the [Bob & Kevin Show](https://bobandkevin.show/).

![Selfie](https://github.com/kgiszewski/ShowBot/blob/master/assets/showbot.jpg)

# Video Demo

https://www.youtube.com/watch?v=M2A2I-AoGWU

# Why?

We needed an intern. No humans applied so we built one.

# What can it do?

It has a voice box (to talk), a voice recognizer (to listen to voice commands), it has a virtual body (a console app) and has learned a few  skills so far:

## Wikipedia Skill
To search Wikipedia:

1) run the intern
2) push `l` for `listen for command`
3) say `search wikipedia for <keyword>`

## CatchPhrase Skill
ShowBot can utter some canned responses:

1) run the intern
2) push `p`
3) make a selection

Alternatively you could:

1) run the intern
2) push `l`
3) utter `say catchphrase <keyword>` where `keyword` is one of your defined words as shown below.

ShowBot learns the catchphrases by reading in a `json` file. Visit the `ShowBot.ConsoleApp.exe.config` file app setting to point to a local file.

That file is in the following format (keyword: catchphrase):

```
{
  "intro": "On today's episode of the Bob & Kevin show...",
  "one": "Hello World!",
  "two": "Gee, I dunno if that's true or not.",
  "three": "Data is the new oil.",
  "four": "Bring the lightning.",
  "five": "What would Zuck do?",
  "wrapup": "Maybe we should wrap this up?",
  "disclaimer": "The thoughts and opinions of the Bob & Kevin show are soley the thoughts of Bob & Kevin and not their employers; past, present and probably not future.",
  "nope": "Sounds like we didn't solve anything again, what do you guys think?"
}
```

## ReadFromFile Skill
ShowBot can utter some canned responses from files as well:

1) run the intern
2) push `r`
3) make a selection

Alternatively you could:

1) run the intern
2) push `l`
3) utter `read from file <keyword>` where `keyword` is one of your defined words as shown below.

ShowBot learns about what to read by reading in a `json` file. Visit the `ShowBot.ConsoleApp.exe.config` file app setting to point to a local file.

That file is in the following format (keyword: file path):

```
{
    "intro": "c:\\dev\\gettysburg.txt"
}
```

> Be sure to use two `\` in the file path for each slash.

Then in your `gettysburg.txt`, it can be just plain text:

```
Four score and seven years ago our fathers brought forth on this continent, a new nation, conceived in Liberty, and dedicated to the proposition that all men are created equal.

Now we are engaged in a great civil war, testing whether that nation, or any nation so conceived and so dedicated, can long endure. We are met on a great battle-field of that war. We have come to dedicate a portion of that field, as a final resting place for those who here gave their lives that that nation might live. It is altogether fitting and proper that we should do this.

But, in a larger sense, we can not dedicate -- we can not consecrate -- we can not hallow -- this ground. The brave men, living and dead, who struggled here, have consecrated it, far above our poor power to add or detract. The world will little note, nor long remember what we say here, but it can never forget what they did here. It is for us the living, rather, to be dedicated here to the unfinished work which they who fought here have thus far so nobly advanced. It is rather for us to be here dedicated to the great task remaining before us -- that from these honored dead we take increased devotion to that cause for which they gave the last full measure of devotion -- that we here highly resolve that these dead shall not have died in vain -- that this nation, under God, shall have a new birth of freedom -- and that government of the people, by the people, for the people, shall not perish from the earth.

Abraham Lincoln
November 19, 1863

```

# Can it do more?

Over time, we'll add more skills and human-like features. Please send a PR or simply open up suggestions as issues.

# Will it take over the world? If so, when?

Unclear. Our best guess is "sometime in the future" it might.

# Birthday
Official ShowBot birthday is May 18, 2019.
