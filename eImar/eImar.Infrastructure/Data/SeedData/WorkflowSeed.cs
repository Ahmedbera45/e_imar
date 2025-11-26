using eImar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eImar.Infrastructure.Data.SeedData
{
    public static class WorkflowSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // 1. Process Definition
            var imarDurumuProcess = new Process { Id = 1, Title = "Bilgi Amaçlı İmar Durumu" };
            modelBuilder.Entity<Process>().HasData(imarDurumuProcess);

            // 2. Role Definitions (as ProcessRole)
            var vatandasRole = new ProcessRole { Id = 1, Name = "Vatandaş", ProcessRef = 1 };
            var belediyeRole = new ProcessRole { Id = 2, Name = "Belediye Yetkilisi", ProcessRef = 1 };
            var raportorRole = new ProcessRole { Id = 3, Name = "Raportör", ProcessRef = 1 };
            var kontrolRole = new ProcessRole { Id = 4, Name = "Kontrol", ProcessRef = 1 };
            var mudurRole = new ProcessRole { Id = 5, Name = "Müdür", ProcessRef = 1 };
            modelBuilder.Entity<ProcessRole>().HasData(vatandasRole, belediyeRole, raportorRole, kontrolRole, mudurRole);

            // 3. Step (State) Definitions
            var basvuruAlindi = new ProcessStep { Id = 1, ProcessRef = 1, Title = "Başvuru Alındı", DisplayTitle = "Başvuru vatadanş tarafından yapıldı, belediye onayı bekleniyor." };
            var belgeKontrol = new ProcessStep { Id = 2, ProcessRef = 1, Title = "Belge Kontrol ve Tahakkuk", DisplayTitle = "Belediye yetkilisi belgeleri kontrol ediyor ve ödeme için tahakkuk oluşturuyor." };
            var odemeBekleniyor = new ProcessStep { Id = 3, ProcessRef = 1, Title = "Ödeme Bekleniyor", DisplayTitle = "Vatandaşın tahakkuk eden ücreti ödemesi bekleniyor." };
            var atamaBekleniyor = new ProcessStep { Id = 4, ProcessRef = 1, Title = "Atama Bekleniyor", DisplayTitle = "İşi yapacak personelin (rapörtör) atanması bekleniyor." };
            var belgeHazirlaniyor = new ProcessStep { Id = 5, ProcessRef = 1, Title = "Belge Hazırlanıyor", DisplayTitle = "Atanan personel tarafından ilgili belgeler (imar durumu, ada etüd krokisi vb.) hazırlanıyor." };
            var raportorImza = new ProcessStep { Id = 6, ProcessRef = 1, Title = "Raportör İmza Bekleniyor", DisplayTitle = "Hazırlanan raporun raportör tarafından imzalanması bekleniyor." };
            var kontrol1Imza = new ProcessStep { Id = 7, ProcessRef = 1, Title = "1. Kontrol İmza Bekleniyor", DisplayTitle = "Raporun ilk kontrol yetkilisi tarafından imzalanması bekleniyor." };
            var kontrol2Imza = new ProcessStep { Id = 8, ProcessRef = 1, Title = "2. Kontrol İmza Bekleniyor", DisplayTitle = "Raporun ikinci kontrol yetkilisi tarafından imzalanması bekleniyor." };
            var mudurImza = new ProcessStep { Id = 9, ProcessRef = 1, Title = "Müdür İmza Bekleniyor", DisplayTitle = "Raporun müdür tarafından imzalanması bekleniyor." };
            var ebsCikis = new ProcessStep { Id = 10, ProcessRef = 1, Title = "EBS Çıkış İşlemleri Bekleniyor", DisplayTitle = "İmzalanan belgenin Elektronik Belge Sistemi'ne (EBS) çıkışının yapılması bekleniyor." };
            var tamamlandi = new ProcessStep { Id = 11, ProcessRef = 1, Title = "Başarıyla Tamamlandı", DisplayTitle = "Süreç başarıyla tamamlandı, vatandaş belgesini görüntüleyebilir." };
            var iptalEdildi = new ProcessStep { Id = 12, ProcessRef = 1, Title = "İptal Edildi", DisplayTitle = "Süreç iptal edildi." };
            var revize = new ProcessStep { Id = 13, ProcessRef = 1, Title = "Revize", DisplayTitle = "Başvuru vatandaşa revize için geri gönderildi." };
            modelBuilder.Entity<ProcessStep>().HasData(
                basvuruAlindi, belgeKontrol, odemeBekleniyor, atamaBekleniyor, belgeHazirlaniyor,
                raportorImza, kontrol1Imza, kontrol2Imza, mudurImza, ebsCikis, tamamlandi, iptalEdildi, revize
            );

            // 4. Action Definitions
            var a_onayla = new ProcessAction { Id = 1, Title = "Başvuruyu Onayla", ProcessStepRef = basvuruAlindi.Id };
            var a_tahakkukGir = new ProcessAction { Id = 2, Title = "Tahakkuk Gir", ProcessStepRef = belgeKontrol.Id };
            var a_odemeYap = new ProcessAction { Id = 3, Title = "Ödeme Yap", ProcessStepRef = odemeBekleniyor.Id };
            var a_ata = new ProcessAction { Id = 4, Title = "Personel Ata", ProcessStepRef = atamaBekleniyor.Id };
            var a_yukle = new ProcessAction { Id = 5, Title = "Belgeleri Yükle", ProcessStepRef = belgeHazirlaniyor.Id };
            var a_imzalaRaportor = new ProcessAction { Id = 6, Title = "Raportör Olarak İmzala", ProcessStepRef = raportorImza.Id };
            var a_imzalaKontrol1 = new ProcessAction { Id = 7, Title = "1. Kontrol Olarak İmzala", ProcessStepRef = kontrol1Imza.Id };
            var a_imzalaKontrol2 = new ProcessAction { Id = 8, Title = "2. Kontrol Olarak İmzala", ProcessStepRef = kontrol2Imza.Id };
            var a_imzalaMudur = new ProcessAction { Id = 9, Title = "Müdür Olarak İmzala", ProcessStepRef = mudurImza.Id };
            var a_ebsCikis = new ProcessAction { Id = 10, Title = "EBS Çıkışını Tamamla", ProcessStepRef = ebsCikis.Id };
            var a_revizeGonder = new ProcessAction { Id = 11, Title = "Revizeye Gönder", ProcessStepRef = basvuruAlindi.Id };
            var a_tekrarBasvur = new ProcessAction { Id = 12, Title = "Tekrar Başvur", ProcessStepRef = revize.Id };
            var a_odemeSuresiDoldu = new ProcessAction { Id = 13, Title = "Ödeme Süresi Doldu", ProcessStepRef = odemeBekleniyor.Id };
            var a_iptalEt = new ProcessAction { Id = 14, Title = "İptal Et", ProcessStepRef = basvuruAlindi.Id };
            var a_iptalEt2 = new ProcessAction { Id = 15, Title = "İptal Et", ProcessStepRef = belgeKontrol.Id };
            var a_iadeEt1 = new ProcessAction { Id = 16, Title = "Raportöre İade Et", ProcessStepRef = kontrol1Imza.Id };
            var a_iadeEt2 = new ProcessAction { Id = 17, Title = "Raportöre İade Et", ProcessStepRef = kontrol2Imza.Id };
            var a_iadeEt3 = new ProcessAction { Id = 18, Title = "Raportöre İade Et", ProcessStepRef = mudurImza.Id };

            modelBuilder.Entity<ProcessAction>().HasData(
                a_onayla, a_tahakkukGir, a_odemeYap, a_ata, a_yukle, a_imzalaRaportor, a_imzalaKontrol1, a_imzalaKontrol2,
                a_imzalaMudur, a_ebsCikis, a_revizeGonder, a_tekrarBasvur, a_odemeSuresiDoldu, a_iptalEt, a_iptalEt2,
                a_iadeEt1, a_iadeEt2, a_iadeEt3
            );
            
            // 5. Action Condition (Transition Logic) Definitions
            modelBuilder.Entity<ProcessActionCondition>().HasData(
                new ProcessActionCondition { Id = 1, OrderOfCondition = 1, ProcessActionRef = a_onayla.Id, ToProcessStepRef = belgeKontrol.Id },
                new ProcessActionCondition { Id = 2, OrderOfCondition = 1, ProcessActionRef = a_tahakkukGir.Id, ToProcessStepRef = odemeBekleniyor.Id },
                new ProcessActionCondition { Id = 3, OrderOfCondition = 1, ProcessActionRef = a_odemeYap.Id, ToProcessStepRef = atamaBekleniyor.Id },
                new ProcessActionCondition { Id = 4, OrderOfCondition = 1, ProcessActionRef = a_ata.Id, ToProcessStepRef = belgeHazirlaniyor.Id },
                new ProcessActionCondition { Id = 5, OrderOfCondition = 1, ProcessActionRef = a_yukle.Id, ToProcessStepRef = raportorImza.Id },
                new ProcessActionCondition { Id = 6, OrderOfCondition = 1, ProcessActionRef = a_imzalaRaportor.Id, ToProcessStepRef = kontrol1Imza.Id },
                new ProcessActionCondition { Id = 7, OrderOfCondition = 1, ProcessActionRef = a_imzalaKontrol1.Id, ToProcessStepRef = kontrol2Imza.Id },
                new ProcessActionCondition { Id = 8, OrderOfCondition = 1, ProcessActionRef = a_imzalaKontrol2.Id, ToProcessStepRef = mudurImza.Id },
                new ProcessActionCondition { Id = 9, OrderOfCondition = 1, ProcessActionRef = a_imzalaMudur.Id, ToProcessStepRef = ebsCikis.Id },
                new ProcessActionCondition { Id = 10, OrderOfCondition = 1, ProcessActionRef = a_ebsCikis.Id, ToProcessStepRef = tamamlandi.Id },
                new ProcessActionCondition { Id = 11, OrderOfCondition = 1, ProcessActionRef = a_revizeGonder.Id, ToProcessStepRef = revize.Id },
                new ProcessActionCondition { Id = 12, OrderOfCondition = 1, ProcessActionRef = a_tekrarBasvur.Id, ToProcessStepRef = basvuruAlindi.Id },
                new ProcessActionCondition { Id = 13, OrderOfCondition = 1, ProcessActionRef = a_odemeSuresiDoldu.Id, ToProcessStepRef = iptalEdildi.Id },
                new ProcessActionCondition { Id = 14, OrderOfCondition = 1, ProcessActionRef = a_iptalEt.Id, ToProcessStepRef = iptalEdildi.Id },
                new ProcessActionCondition { Id = 15, OrderOfCondition = 1, ProcessActionRef = a_iptalEt2.Id, ToProcessStepRef = iptalEdildi.Id },
                new ProcessActionCondition { Id = 16, OrderOfCondition = 1, ProcessActionRef = a_iadeEt1.Id, ToProcessStepRef = belgeHazirlaniyor.Id },
                new ProcessActionCondition { Id = 17, OrderOfCondition = 1, ProcessActionRef = a_iadeEt2.Id, ToProcessStepRef = belgeHazirlaniyor.Id },
                new ProcessActionCondition { Id = 18, OrderOfCondition = 1, ProcessActionRef = a_iadeEt3.Id, ToProcessStepRef = belgeHazirlaniyor.Id }
            );
        }
    }
}
