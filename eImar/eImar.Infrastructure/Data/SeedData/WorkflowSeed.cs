using eImar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eImar.Infrastructure.Data.SeedData
{
    public static class WorkflowSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // 1. Process
            modelBuilder.Entity<Process>().HasData(new Process { Id = 1, Title = "Bilgi Amaçlı İmar Durumu" });

            // 2. Roles (Ref -> Id)
            modelBuilder.Entity<ProcessRole>().HasData(
                new ProcessRole { Id = 1, Name = "Vatandaş", ProcessId = 1 },
                new ProcessRole { Id = 2, Name = "Belediye Yetkilisi", ProcessId = 1 },
                new ProcessRole { Id = 3, Name = "Raportör", ProcessId = 1 },
                new ProcessRole { Id = 4, Name = "Kontrol", ProcessId = 1 },
                new ProcessRole { Id = 5, Name = "Müdür", ProcessId = 1 }
            );

            // 3. Steps (Ref -> Id)
            modelBuilder.Entity<ProcessStep>().HasData(
                new ProcessStep { Id = 1, ProcessId = 1, Title = "Başvuru Alındı", DisplayTitle = "Başvuru yapıldı, onay bekleniyor.", ProcessStepTypeId = 0 }, // TypeId eklendi
                new ProcessStep { Id = 2, ProcessId = 1, Title = "Belge Kontrol ve Tahakkuk", DisplayTitle = "Belge kontrolü yapılıyor.", ProcessStepTypeId = 0 },
                new ProcessStep { Id = 3, ProcessId = 1, Title = "Ödeme Bekleniyor", DisplayTitle = "Ödeme bekleniyor.", ProcessStepTypeId = 0 },
                new ProcessStep { Id = 4, ProcessId = 1, Title = "Atama Bekleniyor", DisplayTitle = "Personel ataması bekleniyor.", ProcessStepTypeId = 0 },
                new ProcessStep { Id = 5, ProcessId = 1, Title = "Belge Hazırlanıyor", DisplayTitle = "Belgeler hazırlanıyor.", ProcessStepTypeId = 0 },
                new ProcessStep { Id = 6, ProcessId = 1, Title = "Raportör İmza Bekleniyor", DisplayTitle = "Raportör onayı bekleniyor.", ProcessStepTypeId = 0 },
                new ProcessStep { Id = 7, ProcessId = 1, Title = "1. Kontrol İmza Bekleniyor", DisplayTitle = "1. Kontrol onayı bekleniyor.", ProcessStepTypeId = 0 },
                new ProcessStep { Id = 8, ProcessId = 1, Title = "2. Kontrol İmza Bekleniyor", DisplayTitle = "2. Kontrol onayı bekleniyor.", ProcessStepTypeId = 0 },
                new ProcessStep { Id = 9, ProcessId = 1, Title = "Müdür İmza Bekleniyor", DisplayTitle = "Müdür onayı bekleniyor.", ProcessStepTypeId = 0 },
                new ProcessStep { Id = 10, ProcessId = 1, Title = "EBS Çıkış", DisplayTitle = "EBS çıkışı yapılıyor.", ProcessStepTypeId = 0 },
                new ProcessStep { Id = 11, ProcessId = 1, Title = "Tamamlandı", DisplayTitle = "Süreç tamamlandı.", ProcessStepTypeId = 0 },
                new ProcessStep { Id = 12, ProcessId = 1, Title = "İptal Edildi", DisplayTitle = "İptal edildi.", ProcessStepTypeId = 0 },
                new ProcessStep { Id = 13, ProcessId = 1, Title = "Revize", DisplayTitle = "Revizeye gönderildi.", ProcessStepTypeId = 0 }
            );

            // 4. Actions (StepRef -> StepId)
            modelBuilder.Entity<ProcessAction>().HasData(
                new ProcessAction { Id = 1, Title = "Onayla", ProcessStepId = 1 },
                new ProcessAction { Id = 2, Title = "Tahakkuk Gir", ProcessStepId = 2 },
                new ProcessAction { Id = 3, Title = "Ödeme Yap", ProcessStepId = 3 },
                new ProcessAction { Id = 4, Title = "Ata", ProcessStepId = 4 },
                new ProcessAction { Id = 5, Title = "Yükle", ProcessStepId = 5 },
                new ProcessAction { Id = 6, Title = "İmzala", ProcessStepId = 6 },
                new ProcessAction { Id = 7, Title = "İmzala", ProcessStepId = 7 },
                new ProcessAction { Id = 8, Title = "İmzala", ProcessStepId = 8 },
                new ProcessAction { Id = 9, Title = "İmzala", ProcessStepId = 9 },
                new ProcessAction { Id = 10, Title = "Tamamla", ProcessStepId = 10 },
                new ProcessAction { Id = 11, Title = "Revize", ProcessStepId = 1 },
                new ProcessAction { Id = 12, Title = "Tekrar", ProcessStepId = 13 },
                new ProcessAction { Id = 13, Title = "Süre Doldu", ProcessStepId = 3 },
                new ProcessAction { Id = 14, Title = "İptal", ProcessStepId = 1 },
                new ProcessAction { Id = 15, Title = "İptal", ProcessStepId = 2 },
                new ProcessAction { Id = 16, Title = "İade", ProcessStepId = 7 },
                new ProcessAction { Id = 17, Title = "İade", ProcessStepId = 8 },
                new ProcessAction { Id = 18, Title = "İade", ProcessStepId = 9 }
            );

            // 5. Conditions (Ref -> Id ve Zorunlu Alanlar)
            modelBuilder.Entity<ProcessActionCondition>().HasData(
                CreateCondition(1, 1, 2), CreateCondition(2, 2, 3), CreateCondition(3, 3, 4),
                CreateCondition(4, 4, 5), CreateCondition(5, 5, 6), CreateCondition(6, 6, 7),
                CreateCondition(7, 7, 8), CreateCondition(8, 8, 9), CreateCondition(9, 9, 10),
                CreateCondition(10, 10, 11), CreateCondition(11, 11, 13), CreateCondition(12, 12, 1),
                CreateCondition(13, 13, 12), CreateCondition(14, 14, 12), CreateCondition(15, 15, 12),
                CreateCondition(16, 16, 5), CreateCondition(17, 17, 5), CreateCondition(18, 18, 5)
            );
        }

        private static ProcessActionCondition CreateCondition(int id, int actionId, int toStepId)
        {
            return new ProcessActionCondition
            {
                Id = id,
                OrderOfCondition = 1,
                ProcessActionId = actionId, // Ref -> Id
                ToProcessStepId = toStepId, // Ref -> Id
                ConditionedProcessEntryAnswerValue = "" // Zorunlu alan dolduruldu
            };
        }
    }
}
