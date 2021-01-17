Feature: TrendyolTest
	Müşteri olarak trendyol sitesinde Login olunur, butik tabları gezilir yüklendiği kontroledlir, rastgele butiğe gidilip ürün 
	görsellerinin yüklendiği kontroledilir, herhangi bir ürünün detayına gidilerek sepete eklenir.

Background:
    * 'Chrome' browser açılır
	* 'https://www.trendyol.com/' sitesine gidilir
	* Popup kapatılır
	* Giriş Yap butonuna tıklanır
	* E-posta adresi 'your_email_adress' olarak girilir
	* Şifre 'your_password' olarak girilir
	* Giriş yap butonuna tıklanır 
	* Login Popup kapatılır
Scenario: BoutiqueControlAndAddTheProductBasket   
	* Kategori tablarına tıklanarak butiklerin yüklendikleri kontrol edilir
	* Rastgele bir taba tıklanır
	* Rastgele butiğe tıklanır 
	* Ürün görselleri kontrol edilir
	* Rastgele ürüne tıklanır
	* Ürün sepete eklenir