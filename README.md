# StringsMix
* The provided code is designed to analyze two strings and yield a formatted output detailing the frequency of lowercase letters in each string. 

* It groups the letters from both strings and computes their occurrences. Using a helper class named StringMix, the frequency and occurrence of each letter are structured and translated into a specified output format.

* The final result is a sequence of these formatted structures, which provides insights into the letter distribution differences between the two input strings.

## Code Flow:

1. `group1` and `group2`: Groups each string by lowercase letters.
2. Initializes a new list `stringMixList` to store the results.
3. Processes `group1` to populate `stringMixList`.
4. Processes `group2` to populate `stringMixList` with letters not already in the list.
5. Assembles an `output` string by:
   * Filtering for `StringMix` items with more than one occurrence.
   * Sorting by occurrence, frequency, and then alphabetically.
   * Formatting each `StringMix` object into the special format.
6. Returns the `output` string.

## Helper Class: `StringMix`

### Properties:

* `Letter`: The character or letter being processed.
* `Occurences`: The count of how many times the letter appears.
* `Frequency`: An enum indicating if the letter is more frequent in `s1`, `s2`, or both strings equally.

### Methods:

* `FormatFrequency()`: Returns a string representation of where the letter is more frequent: `"1"`, `"2"`, or `"="`.
* `FormatLetterOccurence()`: Returns a string containing the letter repeated `Occurences` times.
* `OutputFormattedFrequency()`: Returns the formatted string of frequency and letter occurrences (e.g., `1:aa` or `2:bbb`).

## Special Format:

The output format for each letter is: `[source]:[repeated_letter]`, where:

* `[source]` is either `1`, `2`, or `=` depending on if the letter is more frequent in `s1`, `s2`, or equal in both respectively.
* `[repeated_letter]` is the letter repeated `Occurences` times.

Example: For a letter 'a' that appears 3 times in `s1` and not in `s2`, the formatted string would be `1:aaa`.
