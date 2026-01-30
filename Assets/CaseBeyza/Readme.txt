# Interaction System - [Beyza Çoluk]

> Ludu Arts Unity Developer Intern Case

## Proje Bilgileri

| Bilgi | Değer |
|-------|-------|
| Unity Versiyonu | 6000.1.4f1 |
| Render Pipeline | Built-in / URP / HDRP |
| Case Süresi | 12 |
| Tamamlanma Oranı | %90|

---

## Kurulum

1. Repository'yi klonlayın:
```bash
git clone https://github.com/beyzacoluk/CaseBeyza
```

2. Unity Hub'da projeyi açın
3. `Assets/[ProjectName]/Scenes/SampleScene.unity` sahnesini açın
4. Play tuşuna basın
5. Objelre doğru dönün

---

## Nasıl Test Edilir

### Kontroller

| Tuş | Aksiyon |
|-----|---------|
| WASD/space | Hareket |
| Mouse | Bakış yönü |
| E / F/ Y | Etkileşim |
| [Tab] | [Envanter UI] |
| Mouse/sağ click  | envanter bırakma |
### Test Senaryoları

1. **Door Test:**
   - Kapıya yaklaşın, "Press E to Open" mesajını görün
   - E'ye basın, kapı açılsın
   - Tekrar basın, kapı kapansın

2. **Key + Locked Door Test:**
   - Kilitli kapıya yaklaşın, "Find Key to Open" mesajını görün
   - Anahtarı bulun ve toplayın
   - Kilitli kapıya geri dönün, şimdi açılabilir olmalı

3. **Switch Test:**
   - Button'e yaklaşın ve aktive edin
   - Bağlı nesnenin (kapı) tetiklendiğini görün

4. **Chest Test:**
   - Sandığa yaklaşın
   - E'ye basılı tutun, progress bar dolsun
   - Sandık açılsın ve içindeki item alınsın

---

## Mimari Kararlar

### Interaction System Yapısı

```
[Interaction system player ile sahnedeki etkileşilebilir objeler arasındaki iletişimi düzenler.
Player, trigger alanına girdiğinde objeyi tanır ve yalnızca input’u (E, F, Y) dinleyerek ilgili objeye haber verir. Player neyle etkileştiğini bilmez, sadece etkileşim isteği gönderir.

Etkileşim mantığı objelerin kendi scriptlerinde bulunur (Chest, Door, Switch).
Envanter yönetimi InventoryManager tarafından yapılır, UI sadece gösterim amaçlıdır.
Bu yapı sayesinde sistem modüler, genişletilebilir ve bakımı kolay olur.]
```

**Neden bu yapıyı seçtim:**
> [Player yalnızca input ve tetikleme işini yapıyor. sandık, kapı, switch gibi objeler ise kendi davranışlarından sorumlu. Bu ayrım kodu sadeleştiriyor ve karmaşayı önlüyor.]

**Alternatifler:**
> [Her şeyi tek noktada tek butonla yapmak fakat her farklı etkileşim iin ayrı yapma kararı aldım.]

**Trade-off'lar:**
> [avantaj;Envanter, anahtar, save/load gibi sistemler rahatça entegre edilir.Her etkileşim kendi scriptinde olduğu için yeni obje eklemek kolaydır
dejavantaj;Inspector atamaları dikkat ister
]

### Kullanılan Design Patterns

| Pattern | Kullanım Yeri | Neden |
|Srp|İnteraction|Her scripct işi minimal|


---

## Ludu Arts Standartlarına Uyum

### C# Coding Conventions

| Kural | Uygulandı | Notlar |
|-------|-----------|--------|
| m_ prefix (private fields) | [] / [X ] |Kuralı çok geç gördüm |
| s_ prefix (private static) | [] / [X ] |Kuralı çok geç gördüm |
| k_ prefix (private const) | [] / [X ] |Kuralı çok geç gördüm |
| Region kullanımı | [x] / [ ] | |
| Region sırası doğru | [x] / [ ] | |
| XML documentation | [x] / [ ] | |
| Silent bypass yok | [x] / [ ] | |
| Explicit interface impl. | [x] / [ ] | |

### Naming Convention

| Kural | Uygulandı | Örnekler |
|-------|-----------|----------|
| P_ prefix (Prefab) | [x] / [ ] | P_Door, P_Chest |
| M_ prefix (Material) | [x] / [ ] | M_Door_Wood |
| T_ prefix (Texture) | [x] / [ ] | |
| SO isimlendirme | [x] / [ ] | |

### Prefab Kuralları

| Kural | Uygulandı | Notlar |
|-------|-----------|--------|
| Transform (0,0,0) | [x] / [ ] | |
| Pivot bottom-center | [x] / [ ] | |
| Collider tercihi | [x] / [ ] | Box > Capsule > Mesh |
| Hierarchy yapısı | [x] / [ ] | |

### Zorlandığım Noktalar
> [Standartları uygularken zorlandığınız yerler]

---

## Tamamlanan Özellikler

### Zorunlu (Must Have)

- [x] / [ ] Core Interaction System
  - [x] / [ ] IInteractable interface
  - [x] / [ ] InteractionDetector
  - [x] / [ ] Range kontrolü

- [x] / [ ] Interaction Types
  - [x] / [ ] Instant
  - [x] / [ ] Hold
  - [x] / [ ] Toggle

- [x] / [ ] Interactable Objects
  - [x] / [ ] Door (locked/unlocked)
  - [x] / [ ] Key Pickup
  - [x] / [ ] Switch/Lever
  - [x] / [ ] Chest/Container

- [x] / [ ] UI Feedback
  - [x] / [ ] Interaction prompt
  - [x] / [ ] Dynamic text
  - [x] / [ ] Hold progress bar
  - [x] / [ ] Cannot interact feedback

- [x] / [ ] Simple Inventory
  - [x] / [ ] Key toplama
  - [x] / [ ] UI listesi

### Bonus (Nice to Have)

- [x] Animation entegrasyonu
- [ ] Sound effects
- [x] Multiple keys / color-coded
- [x] Interaction highlight
- [x] Save/Load states
- [x] Chained interactions

---

## Bilinen Limitasyonlar

### Tamamlanamayan Özellikler
1. [Obje physics] - [Fırtına dolayısıyla elektrik 3 saat gitti]
2. [SoundS] - [Süre Yetersizliği]

### Bilinen Bug'lar
yok


### İyileştirme Önerileri
1. [Öneri] - [Nasıl daha iyi olabilirdi]
2. [Öneri]

---

## Ekstra Özellikler

Zorunlu gereksinimlerin dışında eklediklerim:

1. **[Özellik Adı]**
   - Açıklama: [Ne yapıyor]
   - Neden ekledim: [Motivasyon]

2. **[Özellik Adı]**
   - ...

---

## Dosya Yapısı

```
Assets/
├── [ProjectName]/
│   ├── Scripts/
│   │   ├── Runtime/
│   │   │   ├── Core/
│   │   │   │   ├── IInteractable.cs
│   │   │   │   └── ...
│   │   │   ├── Interactables/
│   │   │   │   ├── Door.cs
│   │   │   │   └── ...
│   │   │   ├── Player/
│   │   │   │   └── ...
│   │   │   └── UI/
│   │   │       └── ...
│   │   └── Editor/
│   ├── ScriptableObjects/
│   ├── Prefabs/
│   ├── Materials/
│   └── Scenes/
│       └── TestScene.unity
├── Docs/
│   ├── CSharp_Coding_Conventions.md
│   ├── Naming_Convention_Kilavuzu.md
│   └── Prefab_Asset_Kurallari.md
├── README.md
├── PROMPTS.md
└── .gitignore
```

---

## İletişim

| Bilgi | Değer |
|-------|-------|
| Ad Soyad | [Beyza Çoluk] |
| E-posta | [colukbeyza.com] |
| LinkedIn | [https://www.linkedin.com/in/beyzacoluk/] |
| GitHub | [https://github.com/beyzacoluk] |

---

*Bu proje Ludu Arts Unity Developer Intern Case için hazırlanmıştır.*
