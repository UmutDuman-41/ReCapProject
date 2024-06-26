using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.Messages
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi.";
        public static string ProductNameInvalid = "Ürün ismi geçersiz.";
        public static string MaintenanceTime = "Sistem Bakımda.";
        public static string ProductsListed = "Ürünler Listelendi.";
        public static string ProductsDailyPrice = "Ürün fiyatı 0'dan büyük olmalı.";
        public static string ProductsDeleted = "Ürün Silindi.";
        public static string ProductsUpdated = "Ürün Güncellendi.";
        public static string Added = "Başarılı bir şekilde eklendi.";
        public static string Deleted = "Başarılı bir şekilde silindi.";
        public static string Updated = "Başarılı bir şekilde güncellendi.";
        public static string Listed = "Listeleme Başarılı";
        public static string Error = "İşlem Başarısız";

        public static string PassMustContainBigLetter = "Şifre Büyük Harf İçermelidir";
        public static string PassMustContainSpecialChar = "Şifre Özel Karakter İçermelidir.";
        public static string PassMustContainLetterAndDigit = "Şifre Harf Ve Sayı İçermelidir.";
        public static string PassMustContain = "Kullanıcı Bilgileri Yanlış.";
        public static string AuthorizationDenied = "Yetkiniz Yok.";
        public static string UserRegistered = "Kayıt Oldu.";
        public static string UserNotFound = "Kullanıcı Bulunamadı.";
        public static string PasswordError = "Parola Hatası.";
        public static string SuccessfulLogin = "Başarılı Giriş.";
        public static string UserAlreadyExists = "Kullanıcı Mevcut.";
        public static string AccessTokenCreated = "Token Oluşturuldu.";
    }
}
