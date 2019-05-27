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

ShowBot learns the catchphrases by reading in a `json` file. Visit the `ShowBot.ConsoleApp.exe.config` file app setting to point to a local file.

That file is in the following format:

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

# Can it do more?

Over time, we'll add more skills and human-like features. Please send a PR or simply open up suggestions as issues.

# Will it take over the world? If so, when?

Unclear. Our best guess is "sometime in the future" it might.

# Birthday
Official ShowBot birthday is May 18, 2019.
