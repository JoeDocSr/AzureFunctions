using System;
using System.Collections.Generic;

namespace Empower.DataAccess.Entities.Eviti;

public partial class ContactPayerLineOfBusiness
{
    public Guid Guid { get; set; }

    public Guid PayerGuid { get; set; }

    public string? Name { get; set; }

    public bool DefaultToEBM { get; set; }

    public bool? IsComplete { get; set; }

    public string? EvitiDisplayName { get; set; }

    public bool IsInPublicList { get; set; }

    public Guid? EntityGuid { get; set; }

    public bool IsPayerEmailOn { get; set; }

    public bool HideNonCompliantRegimens { get; set; }

    public bool IsActive { get; set; }

    public bool ShowPerformanceStatus { get; set; }

    public bool ShowPlanCompliantColumn { get; set; }

    public bool ShowBiomarkersForChemo { get; set; }

    public bool ShowBiomarkersForRadiation { get; set; }

    public int TreatmentEndDate { get; set; }

    public int TurnaroundUrgentHours { get; set; }

    public int TurnaroundStandardHours { get; set; }

    public int TurnaroundClockType { get; set; }

    public int TurnaroundClockTypeUrgent { get; set; }

    public bool RunStateMandateAnalyzer { get; set; }

    public bool? IsDefault { get; set; }

    public bool IsUnknownLine { get; set; }

    public bool IsPriorityUserSet { get; set; }

    public bool IsClinicalTrialUserSet { get; set; }

    public bool ShowICD10 { get; set; }

    public Guid ExternalIdentifier { get; set; }

    public string Version { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public bool ShowSiteOfService { get; set; }

    public Guid? CreatedByUserID { get; set; }

    public Guid? ModifiedByUserID { get; set; }

    public bool ShowPharmacyBuyAndBill { get; set; }

    public bool PeerToPeerDoctorRequired { get; set; }

    public bool? CollectNPIandTIN { get; set; }

    public bool DelegatedEntity { get; set; }

    public bool DEFullDelegatedEntityAppeal { get; set; }

    public bool DESendLetterProvider { get; set; }

    public bool DEDisplayReviewSummary { get; set; }

    public string? DEReturnAddressRecipient { get; set; }

    public string? DEReturnAddressStreet1 { get; set; }

    public string? DEReturnAddressStreet2 { get; set; }

    public string? DEReturnAddressCity { get; set; }

    public int? DEReturnAddressState { get; set; }

    public int? DEReturnAddressZipCode { get; set; }

    public bool WebServicesSendAllNDCs { get; set; }

    public bool DESendLetterToSOS { get; set; }

    public bool PeerToPeerRequestResponseClock { get; set; }

    public bool? AllowPartialApprovals { get; set; }

    public bool? ShowAddDrugButton { get; set; }

    public int? FraudDetectionWindow { get; set; }

    public bool CheckProviderEligibility { get; set; }

    public bool CheckRetroAuthorization { get; set; }

    public int? RetroAuthorizationDays { get; set; }

    public bool PreventMedicalOncology { get; set; }

    public bool PreventRadiationOncology { get; set; }

    public string? PreventAlertMessage { get; set; }

    public bool ProviderExclusionEnabledChemo { get; set; }

    public bool ProviderExclusionEnabledRT { get; set; }

    public string? ProviderExclusionMessage { get; set; }

    public bool? GenerateAuthID { get; set; }

    public bool DEFaxLetterToProvider { get; set; }

    public bool DEPhoneOutreach { get; set; }

    public bool AnalyzeDateOfService { get; set; }

    public bool? CheckProvFileSOS { get; set; }

    public bool EvitiEmpower { get; set; }

    public bool Jasper { get; set; }

    public virtual ContactPayer Payer { get; set; } = null!;
}
