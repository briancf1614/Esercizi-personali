import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

// Moduli feature
import { MyFeatureModule1 } from './my-feature1/my-feature1.module';
import { MyFeatureModule2 } from './my-feature2/my-feature2.module';

import { AppComponent } from './app.component';

/* Modules
Consentono di organizzare l'applicazione ed estenderla con funzionalità di moduli/librerie esterne.
Le librerie builtin di Angular sono NgModule, ad esempio: FormsModule, HttpClientModule e RouterModule. 
Molte librerie di terze parti sono disponibili come NgModule: Material Design, Ionic e AngularFire2.
Consolida componenti, service, pipe custom, direttive custom in blocchi coerenti di funzionalità, ciascuno incentrato 
su un'area di funzionalità, un dominio dell'applicazione, un flusso di lavoro o una raccolta comune di utility.

I moduli possono essere definiti in categorie in base alle loro caratteristiche:
- Domain: organizzato in base a una funzionalità o un dominio aziendale
- Routed: il componente principale di NgModule, funge da destinazione di un percorso di navigazione del router
- Routing: fornisce la configurazione del routing per un altro Module
- Service: fornisce servizi di utilità come l'accesso ai dati e la messaggistica
- Widget: rende disponibile un componente, una direttiva custom o una pipe custom ad altri Moduli
- Shared: rende disponibile un insieme di componenti, service, pipe custom, direttive custom ad altri Moduli

I moduli possono essere caricati all'avvio dell'applicazione o caricati in modo lazy/ondemand in modo asincrono dal router.
*/

/* NgModules
NgModule esegue le seguenti operazioni:
- Dichiara componenti, pipe custom e direttive custom del modulo. 
Rende pubblici alcuni di questi elementi in modo che altri moduli possano utilizzarli
- Importa altri moduli con i componenti, le direttive e le pipe di cui hanno bisogno i componenti nel modulo corrente
- Fornisce services utilizzabili dai componenti dell'applicazione
*/
@NgModule({
    /* declarations: []
    Le classi appartenenti al modulo: componenti, direttive custom e pipe custom.
    Sono invisibili ai componenti degli altri moduli a meno che non vengano esportate
    Il compilatore emette un errore se si tenta di dichiarare la stessa classe in più di un modulo
    */
    declarations: [
        AppComponent
    ],
    /* imports: []
    Elenco di moduli esterni necessari al modulo.
    Ad esempio, un componente può utilizzare direttive e pipe di Angular solo se il modulo importa CommonModule
    */
    imports: [
        BrowserModule,
        MyFeatureModule1,
        MyFeatureModule2
    ], 
    exports: [],
    /* Elenco di componenti, direttive custom e pipe custom utilizzabili da altri moduli.
    Gli elementi non esportati esplicitamente dal modulo restano privati.
    L'importazione di un modulo non consente di riesportare automaticamente le importazioni del modulo importato.
    Ad esempio, il modulo 'B' non può usare *ngIf solo perché ha importato il modulo 'A' 
    che ha importato CommonModule. 
    In tal caso, o il modulo 'B' importa CommonModule direttamente, 
    oppure il modulo A riesporta a sua volta CommonModule.
    */

    /* providers: []  
    Elenco dei fornitori di dependency injection.
    Angular registra questi provider configurando l'iniettore del modulo.
    I services diventano disponibili per qualsiasi componente, direttiva, pipe o servizio figlio di questo iniettore.
    Un modulo lazy-loaded ha il proprio iniettore figlio dell'iniettore root.
    */
    providers: [],

    /* bootstrap: []
    Crea i componenti elencati nell'array e inserisce ciascuno nel DOM  del browser.
    Ogni componente bootstrap è la base del proprio albero di componenti creati nel DOM.
    Anche se è possibile inserire più di una struttura di componenti,
    la maggior parte delle applicazioni dispone di una sola struttura
    di componenti e esegue il bootstrap di un singolo componente radice.
    */
    bootstrap: [AppComponent]
})

export class AppModule { }
