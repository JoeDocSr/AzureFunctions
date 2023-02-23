using System;
using System.Collections.Generic;

namespace Empower.DataAccess.Entities.Eviti;

public partial class ContactPayer
{
    public Guid PayerGuid { get; set; }

    public string? PayerID { get; set; }

    public string? Name { get; set; }

    public bool DefaultToEBM { get; set; }

    public string? EligibilityVerifier { get; set; }

    public int? EligibilityVerifierMode { get; set; }

    public Guid? PrimaryAdminContact { get; set; }

    public bool? IsComplete { get; set; }

    public string? RegistrationPin { get; set; }

    public string? EvitiDisplayName { get; set; }

    public string? ParameterDictionary { get; set; }

    public bool? IsInPublicList { get; set; }

    public Guid? EntityGuid { get; set; }

    public bool? IsPayerEmailOn { get; set; }

    public bool HideNonCompliantRegimens { get; set; }

    public bool? IsActive { get; set; }

    public bool ShowPerformanceStatus { get; set; }

    public bool? ShowPlanCompliantColumn { get; set; }

    public bool ShowBiomarkersForChemo { get; set; }

    public bool ShowBiomarkersForRadiation { get; set; }

    public int TreatmentEndDate { get; set; }

    public int TurnaroundUrgentHours { get; set; }

    public int TurnaroundStandardHours { get; set; }

    public int TurnaroundClockType { get; set; }

    public bool RunStateMandateAnalyzer { get; set; }

    public bool IsDefaultLOBAllowed { get; set; }

    public bool ShowMatchTrial { get; set; }

    public bool AllowSecondaryProvider { get; set; }

    public bool AllowReconsiderationStartPayer { get; set; }

    public bool ShowPeerToPeerAsClinical { get; set; }

    public bool ShowReconsiderationAsPostDenial { get; set; }

    public bool GenerateEvitiCodeForMJV { get; set; }

    public bool? IncludeEndDateCushion { get; set; }

    public bool ShowNetworkMessage { get; set; }

    public string? NetworkMessage { get; set; }

    public string? NotInNetworkMessage { get; set; }

    public bool AppealsEnabled { get; set; }

    public bool? ShowInsuranceIDHint { get; set; }

    public string? InsuranceIDHintText { get; set; }

    public bool ShowQuestions { get; set; }

    public int? EligibilityAlgorithm { get; set; }

    public bool? CancerAccess { get; set; }

    public bool? AutoimmuneAccess { get; set; }

    public virtual ICollection<ContactPayerLineOfBusiness> ContactPayerLineOfBusinesses { get; } = new List<ContactPayerLineOfBusiness>();
}
