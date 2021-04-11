using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    //static yaapıyoruz
    //static newlenmez
    public static class Messages
    {
        public static string CarsListed = "\nTüm arabalar listelendi\n";
        public static string CarAdded = "\nAraba eklendi\n";
        public static string CarDeleted = "\nAraba silindi\n";
        public static string CarUpdated = "\nAraba bilgileri güncellendi\n";
        public static string CarDescriptionInvalid = "\nEklenen araba açıklaması en az 2 harften oluşmalıdır.";
        public static string CarDailyPriceInvalid = "\nAraba günlük fiyatı 0 dan büyük olmalıdır.\n";
        public static string CarUndelivered = "\nAraba teslim edilmemiştir, kiralanamaz.\n";
        public static string CarRented = "\nAraba kiralandı.\n";
        public static string UserAdded = "\nKullanıcı eklendi.\n";
        public static string CustomerAdded = "\nMüşteri eklendi.\n";

        public static string CarImageLimitExceed = "\nArabaya ait 5 adet resim bulunmakta, daha fazla resim yükleyemezsiniz.\n";

        public static string UserAlreadyExists = "\nKullanıcı zaten var.\n";
        public static string UserNotFound = "\nKullanıcı bulunamadı.\n";

        public static string PasswordError = "\nParola hatalı.\n";
        public static string UserRegistered = "\nKullanıcı kayıt edildi.\n";

        public static string AuthorizationDenied = "\nYetkilendirme reddedildi.\n";
        public static string AccessTokenCreated = "\n Access Token oluşturuldu.\n";
        public static string TransactionSucceed="\nTransaction işlemi başarılı.\n";

        public static string PaymentSucceed = "\nÖdeme işlemi başarılı.\n";
        
    }
}
