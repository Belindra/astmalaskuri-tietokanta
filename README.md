Lunan astmalääkelaskuri. Idea ohjelmaan lähti liikkeelle astmaan sairastuneesta kissastani, joka käyttää kahta eri lääkettä sairauden hoitoon.
Molemmat lääkkeet ovat inhaloitavia, joten purkista ei näe päällepäin, montako annosta purkissa on jäljellä. Jäljellä olevien annosten laskemista
vaikeuttaa myös se, että molempia lääkkeitä on eri purkeissa eri annosmäärä. Ohjelmassa käyttäjä pystyy syöttämään jomman kumman tai molempien lääkkeiden käyttömäärän, resetoimaan käytettyjen annosten määrän sekä näkemään, paljonko annoksia on vielä jäljellä kummassakin lääkkeessä. Ohjelma toimii suomenkielellä.

Ohjelman ensimmäinen versio tehty käyttäen CSV-tiedostoa annosten määrän laskemiseen (löytyy Githubin repositoriosta nimeltä astmalaskuri). Tässä versiossa käytetään paikallista tietokantaa ja Entity Frameworkia CSV-tiedoston sijaan. Lähdekoodissa ei ole mukana app.config -tiedostoa, joka sisältää tietokannan connection stringin.
