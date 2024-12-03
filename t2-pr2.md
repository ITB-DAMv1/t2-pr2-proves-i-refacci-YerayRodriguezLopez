# 1. Metodologies àgils de desenvolupament de programari
## Característiques principals:
- Iteratives i incrementals: Dividir el projecte en cicles curts (sprints) per lliurar parts funcionals del producte.
- Flexibilitat: Capacitat d'adaptar-se a canvis en els requeriments durant el procés.
- Col·laboració constant: Treball proper amb els clients i comunicació contínua amb l'equip.
- Foment de la qualitat: Revisió i proves freqüents per assegurar que el producte compleix els requisits.

## Escenaris d'ús:
- Projectes amb requisits incerts o en evolució constant.
- Equips multidisciplinaris que necessiten treballar junts de forma flexible.
- Desenvolupament de software amb cicles de lliurament ràpids.

## Exemple: 
- Un equip utilitza Scrum per desenvolupar una aplicació mòbil. Dividixen el projecte en sprints de dues setmanes. Cada sprint inclou planificació, desenvolupament, proves i una demo per al client, que dona feedback per al següent sprint.

# 2. Dobles de prova

- Definició: Els dobles de prova són objectes que simulen el comportament de dependències en proves de software.

- Tipus principals:

    - Fakes: Implementacions simplificades d'una funcionalitat (exemple: una base de dades en memòria).
    - Mocks: Simulen comportaments i verifiquen que certes interaccions tenen lloc. 
    - Stubs: Retornen dades predefinides necessàries per a una prova.
    - Spies: Similars als mocks, però també enregistren les interaccions per verificar-les.
    - Dummies: Objectes passats com a paràmetres, però que no s'utilitzen en el test.

- Exemple en C#:

```
using System;
using Xunit;

namespace TestingExample
{
    // Interfície del servei d'email
    public interface IEmailService
    {
        bool SendEmail(string recipient, string message);
    }

    // Stub que simula el servei d'email
    public class EmailServiceStub : IEmailService
    {
        public bool SendEmail(string recipient, string message)
        {
            return true; // Sempre simula un enviament correcte
        }
    }

    // Classe que depèn del servei d'email
    public class UserService
    {
        private readonly IEmailService _emailService;

        public UserService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public bool SendWelcomeEmail(string recipient)
        {
            string welcomeMessage = "Benvingut al nostre servei!";
            return _emailService.SendEmail(recipient, welcomeMessage);
        }
    }

    // Prova senzilla utilitzant el Stub
    public class UserServiceTests
    {
        [Fact]
        public void SendWelcomeEmail_ShouldReturnTrue_WhenEmailSentSuccessfully()
        {
            // Arrange: Crear el Stub
            var emailService = new EmailServiceStub();
            var userService = new UserService(emailService);

            // Act: Trucar al mètode
            var result = userService.SendWelcomeEmail("example@example.com");

            // Assert: Verificar que el resultat és correcte
            Assert.True(result);
        }
    }
}
```
# 5. Casos de prova per PersonaHelper

## Definir casos de prova

### ClassifyAge(int age)
- 0 → Infància (0).
- 17 → Infància (0).
- 18 → Adulta (1).
- 65 → Adulta (1).
- 66 → Senescència (2).
- 120 → Senescència (2).

### IsEven(int age)
Valors de prova:
- 0 → True.
- 1 → False.
- -2 → True.

### NameAnalyser(string name)
Noms curts (<5 caràcters):
- "Anna" → True, True.
- "Bob" → True, True.
- "John" → True, False.

Noms llargs (>=5 caràcters):
- "Alice" → False, False
- "madam" → False, True.

Entrades no vàlides:
- "" → Llança excepció.
- null → Llança excepció

### VerifyColour(string colour)
Colors calmants:
- "blau" → 0.
- "verd" → 0.

Colors exclusius:
- "vermell" → 1.
- "negre" → 1.

Entrades no vàlides:
- "" → -1.
- null → -1.

### PersonalityTest(string preference)
Preferències vàlides:
- "matí" → 0.
- "nit" → 1.

Preferències desconegudes:
- "tarda" → 2.
- "desconegut" → 2.
- "" → 2.

# Bibliografia

## Pronts ChatGPT

Quines són les característiques de les metodologies àgils i quan s’utilitzen? Dona un exemple pràctic.

Què són els dobles de prova i quins tipus existeixen? Dona un exemple pràctic en C#.
