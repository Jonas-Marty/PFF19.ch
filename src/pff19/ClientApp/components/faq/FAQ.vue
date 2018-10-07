<template>
    <div class="container">
        <h1>FAQ's</h1>
        
        Im Anschluss findest du Antworten auf deine wichtigsten Fragen. Die FAQs werden laufend aktualisiert.

        <h3>Alle</h3>
        Das PFF ist für alle – ob Alt oder Jung, ob Pfadfinder oder nicht, ob von Nah oder von Fern. Du bist herzlich willkommen!
    
        <h3>Alter</h3>
        Das PFF FFS 19 MOSAIK richtet sich primär an Rover und ihre Freunde aus der ganzen Schweiz, Deutschland und Frankreich. Aus rechtlichen und sicherheitstechnischen Gründen liegt die Alterslimite am Freitag- und Samstagabend bei 16 Jahren.
        Am Familientag am Sonntag sind auch alle Jüngeren und Kinder herzlich willkommen.
    
        <h3>Anreise</h3>
        Mit dem ÖV Die Anreise mit dem Zug ist empfehlenswert. Vom Bahnhof Stäfa aus verkehren regelmässige Shuttlebusse zum Festgelände. 
        Mit dem Auto Wenn du dich trotz allem nicht davon abbringen lässt, mit dem Auto anzureisen, findest du das Festgelände problemlos mit jeglichen Navis. Das Angebot an Parkplätzen ist sehr stark begrenzt.  Ein Parkticket für 50 Franken kannst du nur im Voraus erwerben und die Zufahrt zum Festivalgelände ist nur mit einem Parkticket möglich. Es enthält die Zufahrt zum Parkplatz sowie die Parkgebühr bis am Sonntag.
        Eine Ausschilderung im Dorf wird dich zu den Parkplätzen führen.
    
        <h3>Essenspauschale</h3>
        Wir bieten unsere Tickets MIT oder OHNE Essenspauschale an. Damit du auch ohne Pauschale kulinarisch auf deine Kosten kommst, bieten wir dir diverse Foodstände auf dem Gelände. 
        Die Essenspauschale enthält vier Mahlzeiten: Abendessen am Freitag und Samstag, Frühstück am Samstag und Sonntag.
        Bitte bring dein eigenes Essgeschirr mit!

        <h3>Helfereinsatz</h3>
        Helfer bekommen für ihren Einsatz ein vergünstigtes Ticket. Je nach Einsatzbereitschaft ist das Ticket sogar gratis. Falls du Interesse hast, melde dich als Helfer. Damit gehörst du zu den Ersten, welche über die Aufschaltung des Helfertools informiert werden und kannst danach direkt deine Schichten auswählen.
        Falls du weitere Fragen hast, melde dich direkt unter info@pff19.ch
        <ul>
            <li>Melde dich als Helfer: <router-link :to="{name: 'helper'}">Helfer Anmeldung</router-link> </li>
        </ul>

        <h3>Lageplan</h3>
        Das PFF FFS 19 MOSAIK findet auf der Torlenebene in Stäfa im Kanton Zürich statt. 
        Eine Übersicht über das Gelände findest du in Kürze hier. 

        <h3>Tickets</h3>
        Der Ticketvorverkauf startet im Januar 2019. Trage dich bereits jetzt in den Newsletter ein, und gehöre zu den ersten welche über den Verkaufsstart der heissbegehrten Early-Bird-Tickets informiert wird.
        Trage dich bereits jetzt in den Newsletter ein: Verlinkung zu Newsletter-Formular
    
        <h3>Ticket günstiger?</h3>
        Helfer können für ihren Einsatz ein vergünstigtes Ticket beziehen. Je nach Einsatzbereitschaft wird das Ticket günstiger oder sogar gratis. 
        Falls du Interesse hast, melde dich als Helfer. Damit gehörst du zu den Ersten, welche über die Aufschaltung des Helfertools informiert werden und kannst danach direkt deine Schichten auswählen.
        Falls du weitere Fragen hast, melde dich direkt unter info@pff19.ch
        <ul>
            <li>Melde dich als Helfer: <router-link :to="{name: 'helper'}">Helfer Anmeldung</router-link></li>
        </ul>

        <h3>Zeltplatz</h3>
        Übernachten kannst du auf dem Zeltplatz direkt neben dem Festivalgelände. Der Zeltplatz ist im 3-Tagespass inbegriffen.
        
        <div class="col">
            <div class="row">
                <router-link :to="{name: 'contact'}">
                <div class="btn btn-primary"> Andere Fragen</div>
                </router-link>
            </div>
        </div>
    </div>
</template>

<script>
export default {

}
</script>

<style lang='scss' scoped>
    .container {
        padding-top: 100px;
    }

    h3 {
        margin-top: 40px;
    }

    .row {
        margin-top: 40px;
    }
</style>
