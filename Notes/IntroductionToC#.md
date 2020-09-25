# C# Fundamentals

## Guidelines when naming an identifier
1. **DO** favor clarity over weird word when naming an identifier
2. **DO NOT** use shorter word for other words in identifiers names
3. **DO** when naming identifers, use camelCase - same for variables

### Keywords
1. Keywords (string, int, and so on) may be used as identifiers, if they include a @ as prefix, so int @int

### Type definition
1. **DO** name classes with nouns or noun phrases
2. **DO** use PascalCasing for all class names

### System.Console.Read()
1. Read the input of only one character. Return false, if no characters


### Types of comment
1. //comment single line comment
2. /* comment */ span over multiple lines
3. /** comment **/ same as above, but the compiler creates a text file (page 30 in book)
4. ///comment - same as //, but XML saves the comments into a seperate text file

5. **Guidelines**
    1. **DO NOT** use comment unless they desribe something that is not obvious to someone other than the developer who wrote the code
    2. **DO** favor writing clearer code over entering comments to clarify a complicated algorithm

## Extensible Markup language (XML)
1. Used within Web applications and for exchanging data within Web applications
2. Also includes information that desrices the data - metadata
    1. Starts with a header, indicating version as well as character encoding
        ```XML
        <?xml version="1.0" encoding="utf-8" ?>
        <body>
            <book title="Essential C# 7.0">
                <chapters>
                    <chapter title="Introducing C#"/>
                    <chapter title="Data Types"/>
                    ...
                </chapters>
            </book>
        </body>
        ```


    
