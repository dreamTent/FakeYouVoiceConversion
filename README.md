# FakeYouVoiceConversion
A c# .net library for communicating with the FakeYou Voice Conversion api

# Example Usage
## Get Voice Conversion Models List
````c#
Client client = new Client();
List<Model> result = await client.GetVoiceList();
````
Model Variables:
- Token: string
- ModelType: string
- Title: string
- Creator: Creator
- CreatorSetVisibility: string
- IetfLanguageTag: string
- IetfPrimaryLanguageSubtag: string
- IsFrontPageFeatured: bool
- CreatedAt: DateTime
- UpdatedAt: DateTime

## Voice Conversion
To convert the audio you need to give following to the MakeVoiceConversion function: the Token of the model, and a byte[] that holds your audio.
In this example i am using "weight_4c230zwawr3dm0jqcce16xtvf" which is the voice of WeirdAl.
````c#
Client client = new Client();
byte[] resultBytes = await client.MakeVoiceConversion("weight_4c230zwawr3dm0jqcce16xtvf", fileBytes);
````

## Login
If you have a premium or plus subscription you may want to log in, to get faster responses and be able to convert longer audio files.
Here is how you can login:
````c#
Client client = new Client();
if (await client.Login("username/email", "password")){
    byte[] resultBytes = await client.MakeVoiceConversion("weight_4c230zwawr3dm0jqcce16xtvf", fileBytes);
}
````
The login function returns true if the login was successfull or the user was already logged in.
It returns false if the login was unsucessfull.

## Logout
If you have logged in, don't forget to logout!
You can do that simply by calling Logout()
````c#
await client.Logout();
````
If the logout was sucessfull it returns true, else it returns false