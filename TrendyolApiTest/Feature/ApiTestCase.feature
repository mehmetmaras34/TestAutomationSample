Feature: ApiTestCase
    Belirlenen API test senaryolarının gerçekleştirilmesi.    

Background:
	* Apideki kitap listesinin boş olduğu doğrulanır

Scenario: TitleIsRequired
	* Title bilgisi girilmeden kitap eklenmeye çalışılır

Scenario: AuthorIsRequired
	* Author bilgisi girilmeden kitap eklenmeye çalışılır

Scenario: TitleIsEmpty
	* Title bilgisi boş girilerek kitap eklenmeye çalışılır

Scenario: AuthorIsEmpty
	* Author bilgisi boş girilerek kitap eklenmeye çalışılır

Scenario: IdIsReadonlyParameter
	* Id bilgisi girilerek kayıt eklenmeye çalışılır

Scenario: AddNewBook
	* Title bilgisi 'Nutuk', author bilgisi 'Mustafa Kemal Atatürk' olarak yeni kitap eklenir '1' id numarası ile çağrılır parametreler kontrol edilir

Scenario: AddNewSameBook
	* Title bilgisi 'Nutuk', author bilgisi 'Mustafa Kemal Atatürk' olan kitabın iki kere eklenemdiği kontrol edilir
		
